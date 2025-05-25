using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace medilabcsharp
{
    public partial class adminDocter : Form
    {
        private BindingSource bindingSource = new BindingSource();

        public adminDocter()
        {
            InitializeComponent();
            LoadPatients();
            this.WindowState = FormWindowState.Maximized;
            InitializeGenderComboBox(); 
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void InitializeGenderComboBox()
        {
            gender.Items.AddRange(new string[] { "Male", "Female" });
            gender.SelectedIndex = 0;
        }

        private void LoadPatients()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"SELECT UserID, firstName, lastName, DateOfBirth, 
                           Gender, phone, Email, Role, PasswordHash
                           FROM Users 
                           WHERE Role != 'Admin'
                           ORDER BY 
                               CASE Role 
                                   WHEN 'Doctor' THEN 1 
                                   WHEN 'Patient' THEN 2 
                                   WHEN 'Secretary' THEN 3 
                                   ELSE 4 
                               END,
                           lastName, firstName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    dataGridView1.AutoResizeColumns();

                    // Set PasswordChar for the password column if it exists
                    if (dataGridView1.Columns.Contains("PasswordHash"))
                    {
                        dataGridView1.Columns["PasswordHash"].HeaderText = "Password";
                        dataGridView1.Columns["PasswordHash"].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            SqlConnection conn = null;

            try
            {
  
                conn = DatabaseHelper.GetConnection();



                string query = @"INSERT INTO Users 
                                (firstName, lastName, DateOfBirth, Gender,phone, Email, PasswordHash,Role)
                                VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Phone, @Email,@MotDePasse,'Patient')";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpBirthDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Gender", gender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Phone", phoneNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", email.Text.Trim());

                    cmd.Parameters.AddWithValue("@Role",role.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MotDePasse", password.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPatients();
                        ClearFields();
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627)  // Unique constraint violation
                {
                    MessageBox.Show("A patient with this email already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Password is required");
                return false;
            }

            if (password.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");
                return false;
            }
            if (string.IsNullOrWhiteSpace(firstName.Text))
            {
                MessageBox.Show("First name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastName.Text))
            {
                MessageBox.Show("Last name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(email.Text) || !email.Text.Contains("@"))
            {
                MessageBox.Show("Valid email is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            firstName.Clear();
            lastName.Clear();
            dtpBirthDate.Value = DateTime.Now;
            gender.SelectedIndex = 0;
            role.SelectedIndex = 0;
            phoneNum.Clear();
            email.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && !dataGridView1.CurrentRow.IsNewRow)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                firstName.Text = row.Cells["firstName"].Value?.ToString() ?? "";
                lastName.Text = row.Cells["lastName"].Value?.ToString() ?? "";
                email.Text = row.Cells["Email"].Value?.ToString() ?? "";
                phoneNum.Text = row.Cells["phone"].Value?.ToString() ?? "";
                password.Text = row.Cells["PasswordHash"].Value?.ToString() ?? "";

                if (row.Cells["DateOfBirth"].Value != null &&
                    DateTime.TryParse(row.Cells["DateOfBirth"].Value.ToString(), out DateTime birthDate))
                {
                    dtpBirthDate.Value = birthDate;
                }

                string genderValue = row.Cells["Gender"].Value?.ToString() ?? "";
                if (gender.Items.Contains(genderValue))
                {
                    gender.SelectedItem = genderValue;
                }

                string roleValue = row.Cells["Role"].Value?.ToString() ?? "";
                if (role.Items.Contains(roleValue))
                {
                    role.SelectedItem = roleValue;
                }

                currentPatientId = row.Cells["UserID"].Value != null ?
                                 Convert.ToInt32(row.Cells["UserID"].Value) : -1;
            }
        }
        private int currentPatientId = -1;
        ////////////////////////////////// Update patient/////////////////////////////////////////////////////
        private void update_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            if (currentPatientId <= 0)
            {
                MessageBox.Show("Please select a patient to update");
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                conn = DatabaseHelper.GetConnection();

                string query = @"UPDATE Users SET 
                          firstName = @Nom,
                          lastName = @Prenom,
                          DateOfBirth = @DateNaissance,
                          gender = @Gender,
                          phone = @Telephone,
                          Email = @Email,
                          PasswordHash=@Password
                          WHERE UserID = @PatientID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nom", firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Prenom", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateNaissance", dtpBirthDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Gender", gender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Telephone", phoneNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@PatientID", currentPatientId);
                    cmd.Parameters.AddWithValue("@Password", password.Text.Trim());


                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient updated successfully!");
                        LoadPatients(); // Refresh the DataGridView
                        ClearFields();
                        currentPatientId = -1; // Reset the selected patient
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627) // Unique constraint violation (duplicate email)
                {
                    MessageBox.Show("This email is already in use by another patient");
                }
                else
                {
                    MessageBox.Show($"Database error: {sqlEx.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient: {ex.Message}");
            }
        }

        ////////////////////////////////// DELETE patient/////////////////////////////////////////////////////

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            // Check if a patient is selected
            if (currentPatientId <= 0)
            {
                MessageBox.Show("Please select a patient to delete",
                               "No Selection",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this patient record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            try
            {
                conn = DatabaseHelper.GetConnection();



                string query = "DELETE FROM Users WHERE UserID = @PatientID ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", currentPatientId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient deleted successfully",
                                      "Success",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Refresh the data and UI
                        LoadPatients();
                        ClearFields();
                        currentPatientId = -1; // Reset selected patient
                    }
                    else
                    {
                        MessageBox.Show("No patient was deleted",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }

            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Cannot delete patient - medical records exist",
                                  "Constraint Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting patient: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new adminDashboard().Show();
        }

        private void adminPatient_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}