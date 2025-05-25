using medilabcsharp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace MedicalCenter
{
    public partial class ManageDoctorAvailabilitiesForm : Form
    {
        private DataTable dtDoctors;
        private DataTable dtAvailabilities;
        private int currentDoctorId = -1;

        public ManageDoctorAvailabilitiesForm()
        {
            InitializeComponent();
        }

        private void ManageDoctorAvailabilitiesForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvAvailabilities.AutoGenerateColumns = false;
            dgvAvailabilities.Columns.Clear();

            // Add columns with proper mapping
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn
            {
                Name = "colAvailabilityID",  // Unique name for the column
                DataPropertyName = "AvailabilityID", // Must match DataTable column name
                HeaderText = "ID",
                Width = 60,
                Visible = false // Hide if you don't want to show it
            };
            dgvAvailabilities.Columns.Add(colId);

            // Day Column
            DataGridViewTextBoxColumn colDay = new DataGridViewTextBoxColumn
            {
                Name = "colDay",
                DataPropertyName = "DayOfWeekName",
                HeaderText = "Day",
                Width = 120
            };
            dgvAvailabilities.Columns.Add(colDay);

            // Start Time Column
            DataGridViewTextBoxColumn colStart = new DataGridViewTextBoxColumn
            {
                Name = "colStart",
                DataPropertyName = "StartTime",
                HeaderText = "Start Time",
                Width = 120
            };
            dgvAvailabilities.Columns.Add(colStart);

            // End Time Column
            DataGridViewTextBoxColumn colEnd = new DataGridViewTextBoxColumn
            {
                Name = "colEnd",
                DataPropertyName = "EndTime",
                HeaderText = "End Time",
                Width = 120
            };
            dgvAvailabilities.Columns.Add(colEnd);
        }

        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"SELECT UserID, firstName + ' ' + lastName AS DoctorName 
                                   FROM Users WHERE Role = 'Doctor' 
                                   ORDER BY lastName, firstName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    dtDoctors = new DataTable();
                    adapter.Fill(dtDoctors);

                    cmbDoctors.DataSource = dtDoctors;
                    cmbDoctors.DisplayMember = "DoctorName";
                    cmbDoctors.ValueMember = "UserID";

                    if (dtDoctors.Rows.Count > 0)
                    {
                        currentDoctorId = Convert.ToInt32(dtDoctors.Rows[0]["UserID"]);
                        LoadDoctorAvailabilities(currentDoctorId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctorAvailabilities(int doctorId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT AvailabilityID,  
                       DayOfWeek AS OriginalDayNumber,
                       CASE DayOfWeek  
                           WHEN 1 THEN 'Sunday'  
                           WHEN 2 THEN 'Monday'  
                           WHEN 3 THEN 'Tuesday'  
                           WHEN 4 THEN 'Wednesday'  
                           WHEN 5 THEN 'Thursday'  
                           WHEN 6 THEN 'Friday'  
                           WHEN 7 THEN 'Saturday'  
                           ELSE 'Unknown'  
                       END AS DayOfWeekName,  
                       CONVERT(varchar, StartTime, 108) AS StartTime,  
                       CONVERT(varchar, EndTime, 108) AS EndTime  
                FROM DoctorAvailability  
                WHERE DoctorID = @DoctorID  
                ORDER BY DayOfWeek, StartTime";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@DoctorID", doctorId);

                    dtAvailabilities = new DataTable();
                    adapter.Fill(dtAvailabilities);

                    dgvAvailabilities.DataSource = dtAvailabilities;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading availabilities: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GetDayName(int dayNumber)
        {
            // Convert 1-7 to day names (1=Sunday, 7=Saturday)
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[dayNumber % 7];
        }

        private void cmbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue != null && cmbDoctors.SelectedValue is int)
            {
                currentDoctorId = (int)cmbDoctors.SelectedValue;
                LoadDoctorAvailabilities(currentDoctorId);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new AvailabilityDialog(); // Create your own form for data entry
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        string query = @"INSERT INTO DoctorAvailability 
                                 (DoctorID, DayOfWeek, StartTime, EndTime) 
                                 VALUES (@DoctorID, @DayOfWeek, @StartTime, @EndTime)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@DoctorID", currentDoctorId);
                        cmd.Parameters.AddWithValue("@DayOfWeek", (int)dialog.SelectedDay);
                        cmd.Parameters.AddWithValue("@StartTime", dialog.StartTime);
                        cmd.Parameters.AddWithValue("@EndTime", dialog.EndTime);
                        cmd.ExecuteNonQuery();
                    }

                    LoadDoctorAvailabilities(currentDoctorId);
                    MessageBox.Show("Availability added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding availability: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAvailabilities.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an availability to delete.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Get the selected row's data directly from the DataTable
                int rowIndex = dgvAvailabilities.SelectedRows[0].Index;
                DataRow row = dtAvailabilities.Rows[rowIndex];

                // Safely get the ID
                if (!row.Table.Columns.Contains("AvailabilityID") || row["AvailabilityID"] == DBNull.Value)
                {
                    MessageBox.Show("Availability ID column not found in data source.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int availabilityId = Convert.ToInt32(row["AvailabilityID"]);

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this availability?",
                                           "Confirm Delete",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                  
                        string query = "DELETE FROM DoctorAvailability WHERE AvailabilityID = @AvailabilityID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@AvailabilityID", availabilityId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Refresh data
                                LoadDoctorAvailabilities(currentDoctorId);
                                MessageBox.Show("Availability deleted successfully.", "Success",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No availability was deleted.", "Warning",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting availability: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvAvailabilities_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvAvailabilities.ClearSelection();
                dgvAvailabilities.Rows[e.RowIndex].Selected = true;
                contextMenuStrip1.Show(dgvAvailabilities, e.Location);
            }
        }

   

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }

   

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}