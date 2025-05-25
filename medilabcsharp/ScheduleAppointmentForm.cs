using Microsoft.VisualBasic;
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
    public partial class ScheduleAppointmentForm : Form
    {
        private int userId;

        private const string ConnectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        public ScheduleAppointmentForm()
        {
            InitializeComponent();
            this.userId = CurrentUser.Id;
            LoadPatients();
            LoadDoctors();
            dtpDate.MinDate = DateTime.Today;
        }
        private void LoadPatients()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT UserID, Username FROM Users WHERE Role = 'Patient' ORDER BY Username";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbPatient.DisplayMember = "Username";
                cmbPatient.ValueMember = "UserID";
                cmbPatient.DataSource = dt;
            }
        }

        private void LoadDoctors()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT UserID, Username, specialization FROM Users WHERE Role = 'Doctor' ORDER BY Username";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbDoctor.DisplayMember = "Username";
                cmbDoctor.ValueMember = "UserID";
                cmbDoctor.DataSource = dt;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableTimeSlots();
        }

        private void LoadAvailableTimeSlots()
        {
            if (cmbDoctor.SelectedValue == null) return;

            int doctorId = (int)cmbDoctor.SelectedValue;
            DateTime selectedDate = dtpDate.Value.Date;

            lstTimeSlots.Items.Clear();

            // Generate time slots (example: 8AM to 5PM with 30-minute intervals)
            for (DateTime time = selectedDate.AddHours(8); time < selectedDate.AddHours(17); time = time.AddMinutes(30))
            {
                if (IsTimeSlotAvailable(doctorId, time))
                {
                    lstTimeSlots.Items.Add(time.ToString("HH:mm"));
                }
            }
        }
        private bool IsTimeSlotAvailable(int doctorId, DateTime time)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Appointments 
                               WHERE DoctorID = @DoctorID 
                               AND AppointmentDate BETWEEN @StartTime AND @EndTime
                               AND Status != 'Cancelled'";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DoctorID", doctorId);
                command.Parameters.AddWithValue("@StartTime", time);
                command.Parameters.AddWithValue("@EndTime", time.AddMinutes(29));

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstTimeSlots.SelectedItem == null)
            {
                MessageBox.Show("Please select a time slot.");
                return;
            }

            DateTime appointmentTime = dtpDate.Value.Date +
                TimeSpan.Parse(lstTimeSlots.SelectedItem.ToString());

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"INSERT INTO Appointments 
                               (PatientID, DoctorID, AppointmentDate, DurationMinutes, Reason, Status)
                               VALUES (@PatientID, @DoctorID, @AppointmentDate, @Duration, @Reason, 'Scheduled')";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientID", cmbPatient.SelectedValue);
                command.Parameters.AddWithValue("@DoctorID", cmbDoctor.SelectedValue);
                command.Parameters.AddWithValue("@AppointmentDate", appointmentTime);
                command.Parameters.AddWithValue("@Duration", numDuration.Value);
                command.Parameters.AddWithValue("@Reason", txtReason.Text);

                connection.Open();
                command.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void ScheduleAppointmentForm_Load(object sender, EventArgs e)
        {

        }




    }
}
