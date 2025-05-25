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
    public partial class UpdateAppointmentForm : Form

    {
        private int appointmentId;
        private const string ConnectionString =
         @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        public UpdateAppointmentForm(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            LoadAppointmentData();
            LoadDoctors();
        }

        private void UpdateAppointmentForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadAppointmentData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT a.PatientID, a.DoctorID, a.AppointmentDate, 
                                a.DurationMinutes, a.Reason, a.Status,
                                p.Username AS PatientName, d.Username AS DoctorName
                                FROM Appointments a
                                INNER JOIN Users p ON a.PatientID = p.UserID
                                INNER JOIN Users d ON a.DoctorID = d.UserID
                                WHERE a.AppointmentID = @AppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Display existing data
                    lblPatientName.Text = reader["PatientName"].ToString();
                    lblCurrentDoctor.Text = reader["DoctorName"].ToString();
                    dtpDate.Value = Convert.ToDateTime(reader["AppointmentDate"]);
                    numDuration.Value = Convert.ToInt32(reader["DurationMinutes"]);
                    txtReason.Text = reader["Reason"].ToString();
                    cmbStatus.SelectedItem = reader["Status"].ToString();
                }
                reader.Close();
            }
        }

        private void LoadDoctors()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT UserID, Username FROM Users WHERE Role = 'Doctor' ORDER BY Username";
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

            // Generate time slots (8AM to 5PM with 30-minute intervals)
            for (DateTime time = selectedDate.AddHours(8); time < selectedDate.AddHours(17); time = time.AddMinutes(30))
            {
                if (IsTimeSlotAvailable(doctorId, time))
                {
                    lstTimeSlots.Items.Add(time.ToString("HH:mm"));
                }
            }

            // Select current time if available
            DateTime currentTime = dtpDate.Value;
            string currentTimeStr = currentTime.ToString("HH:mm");
            if (lstTimeSlots.Items.Contains(currentTimeStr))
            {
                lstTimeSlots.SelectedItem = currentTimeStr;
            }
        }

        private bool IsTimeSlotAvailable(int doctorId, DateTime time)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Appointments 
                               WHERE DoctorID = @DoctorID 
                               AND AppointmentDate BETWEEN @StartTime AND @EndTime
                               AND Status != 'Cancelled'
                               AND AppointmentID != @AppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DoctorID", doctorId);
                command.Parameters.AddWithValue("@StartTime", time);
                command.Parameters.AddWithValue("@EndTime", time.AddMinutes(29));
                command.Parameters.AddWithValue("@AppointmentID", appointmentId);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstTimeSlots.SelectedItem == null)
            {
                MessageBox.Show("Please select a time slot.");
                return;
            }

            DateTime newDateTime = dtpDate.Value.Date +
                TimeSpan.Parse(lstTimeSlots.SelectedItem.ToString());

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"UPDATE Appointments 
                               SET DoctorID = @DoctorID,
                                   AppointmentDate = @AppointmentDate,
                                   DurationMinutes = @Duration,
                                   Reason = @Reason,
                                   Status = @Status
                               WHERE AppointmentID = @AppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DoctorID", cmbDoctor.SelectedValue);
                command.Parameters.AddWithValue("@AppointmentDate", newDateTime);
                command.Parameters.AddWithValue("@Duration", numDuration.Value);
                command.Parameters.AddWithValue("@Reason", txtReason.Text);
                command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                command.Parameters.AddWithValue("@AppointmentID", appointmentId);

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


    }

}
