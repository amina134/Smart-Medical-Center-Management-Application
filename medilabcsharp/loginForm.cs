using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BCrypt.Net;

namespace medilabcsharp
{
    public partial class loginForm : Form
    {
        private const string ConnectionString =
            @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;   
              Password=aminakounieya14;
              TrustServerCertificate=True;";

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginBut_Click(object sender, EventArgs e)
        {
            string username = userName.Text.Trim();
            string password = Password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password",
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (AuthenticateUser(username, password))
                {
                    MessageBox.Show($"Login successful! Welcome {CurrentUser.Name}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid username or password",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                // Modified to get all necessary user information
                string sql = @"SELECT UserID, FirstName, LastName, Role, PasswordHash 
                              FROM Users 
                              WHERE firstName = @username";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            string role = reader.GetString(3);
                            string storedHash = reader.GetString(4);

                            if (password == storedHash) // For now keeping plain text comparison
                            {
                                // Set current user information
                                CurrentUser.Login(
                                    id: userId,
                                    role: role,
                                    name: $"{firstName} {lastName}"
                                );

                                OpenRoleDashboard(role);
                                this.Hide();
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Invalid password");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found");
                            return false;
                        }
                    }
                }
            }
        }

        private void OpenRoleDashboard(string role)
        {
            switch (role.ToLower())
            {
                case "admin":
                    new adminDashboard().Show();
                    break;
                case "doctor":
                    new doctorDashboard().Show(); // Now properly tracking current user
                    break;
                case "patient":
                    new patientDashboard().Show();
                    break;
                case "secretary":
                    new secretaryDashboard().Show();
                    break;
                default:
                    MessageBox.Show("Unknown user role");
                    Application.Exit();
                    break;
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

    }
}
