using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace medilabcsharp
{
    public partial class doctorDashboard : Form
    {
        private const string ConnectionString =
            @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        private int selectedPatientId = -1;
        private int selectedAppointmentId = -1;

        public doctorDashboard()
        {
            InitializeComponent();
            LoadDoctorAppointments();
            ConfigureDataGridView();
        }

        private void LoadDoctorAppointments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT 
                            a.AppointmentID,
                            a.PatientID, 
                            u.FirstName + ' ' + u.LastName AS Patient,
                            FORMAT(a.AppointmentDate, 'yyyy-MM-dd HH:mm') AS [Date],
                            a.DurationMinutes AS Duration,
                            a.Reason,
                            a.Status
                          FROM Appointments a
                          JOIN Users u ON a.PatientID = u.UserID
                          WHERE a.DoctorID = @doctorId
                          ORDER BY a.AppointmentDate";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@doctorId", CurrentUser.Id);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewAppointments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Basic configuration
            dataGridViewAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAppointments.ReadOnly = true;
            dataGridViewAppointments.AllowUserToAddRows = false;
            dataGridViewAppointments.RowHeadersVisible = false;
            dataGridViewAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Format columns


            if (dataGridViewAppointments.Columns.Contains("AppointmentID"))
                dataGridViewAppointments.Columns["AppointmentID"].Visible = false;

            if (dataGridViewAppointments.Columns.Contains("Patient"))
                dataGridViewAppointments.Columns["Patient"].HeaderText = "Patient Name";

            if (dataGridViewAppointments.Columns.Contains("Date"))
                dataGridViewAppointments.Columns["Date"].HeaderText = "Appointment Date";

            if (dataGridViewAppointments.Columns.Contains("Duration"))
                dataGridViewAppointments.Columns["Duration"].HeaderText = "Duration (min)";

            if (dataGridViewAppointments.Columns.Contains("Reason"))
                dataGridViewAppointments.Columns["Reason"].HeaderText = "Reason for Visit";

            if (dataGridViewAppointments.Columns.Contains("Status"))
                dataGridViewAppointments.Columns["Status"].HeaderText = "Status";

            dataGridViewAppointments.CellClick += dataGridViewAppointments_CellContentClick;
        }

        private void dataGridViewAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAppointments.Rows[e.RowIndex];
                selectedPatientId = Convert.ToInt32(row.Cells["PatientID"].Value);
                selectedAppointmentId = Convert.ToInt32(row.Cells["AppointmentID"].Value);

                // Enable medical record buttons
                btnViewMedicalRecord.Enabled = true;

            }
        }

        private void btnViewMedicalRecord_Click(object sender, EventArgs e)
        {
            if (selectedPatientId <= 0) return;

            var medicalRecordsForm = new PatientMedicalRecords(selectedPatientId, CurrentUser.Id);
            medicalRecordsForm.ShowDialog();
        }

        private void doctorDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}