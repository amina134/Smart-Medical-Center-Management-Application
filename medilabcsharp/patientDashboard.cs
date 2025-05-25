using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilabcsharp
{

    public partial class patientDashboard : Form
    {
        private int patientId;
        private const string ConnectionString =
         @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";

        public patientDashboard()
        {
            InitializeComponent();
            Load += patientDashboard_Load;
        }

        private void patientDashboard_Load(object sender, EventArgs e)
        {
            newRdvButton.Click += ShowNewRdvForm;


            LoadAllAppointments();
        }

        private void patientDashboard_Load_1(object sender, EventArgs e)
        {

        }
        private void LoadAllAppointments()
        {
            try
            {
                List<Appointment> appointments = new List<Appointment>();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT 
                            a.AppointmentID, 
                            a.AppointmentDate, 
                            u.firstName + ' ' + u.lastName AS DoctorName, 
                            u.specialization AS Specialty, 
                            a.Status, 
                            a.Reason 
                         FROM Appointments a
                         JOIN Users u ON a.DoctorID = u.UserID
                         WHERE a.PatientID = @PatientID
                         ORDER BY a.AppointmentDate DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PatientID", CurrentUser.Id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            AppointmentId = reader.GetInt32(0),
                            AppointmentDate = reader.GetDateTime(1),
                            DoctorName = reader.GetString(2),
                            Specialty = reader.GetString(3),
                            Status = reader.GetString(4),
                            Reason = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                        });
                    }
                }

                upcomingRdvGrid.DataSource = appointments;

                // Format the grid
                upcomingRdvGrid.AutoGenerateColumns = true;
                upcomingRdvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Add color coding for status
                foreach (DataGridViewRow row in upcomingRdvGrid.Rows)
                {
                    if (row.Cells["Status"].Value != null)
                    {
                        string status = row.Cells["Status"].Value.ToString();
                        if (status == "Completed")
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        else if (status == "Cancelled")
                            row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNewRdvForm(object sender, EventArgs e)
        {
            using (var form = new NewAppointmentForm(patientId)) // Pass patientId
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadAllAppointments(); // Refresh data
            }
        }


        private void rdvTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void viewRecordButton_Click(object sender, EventArgs e)
        {
            using (var medicalRecordForm = new MedicalRecordFormP(patientId))
            {
                medicalRecordForm.ShowDialog();
            }
        }
    }
}
