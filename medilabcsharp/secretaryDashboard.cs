using MedicalCenter;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace medilabcsharp
{
    public partial class secretaryDashboard : Form
    {
        private int userId;

        private const string ConnectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        public secretaryDashboard()
        {
            InitializeComponent();
            this.userId = CurrentUser.Id;


            LoadAppointments();
            LoadPatients();
        }

        private void secretaryDashboard_Load(object sender, EventArgs e)
        {

        }
        private void LoadAppointments()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT a.AppointmentID, p.Username AS PatientName, d.Username AS DoctorName, 
                                   a.AppointmentDate, a.DurationMinutes, a.Reason, a.Status
                                   FROM Appointments a
                                   INNER JOIN Users p ON a.PatientID = p.UserID
                                   INNER JOIN Users d ON a.DoctorID = d.UserID
                                   ORDER BY a.AppointmentDate";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAppointments.DataSource = dt;
                    dgvAppointments.Columns["AppointmentID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointments: " + ex.Message);
                }
            }
        }
        //
        private void LoadPatients()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserID, Username, Email FROM Users WHERE Role = 'Patient' ORDER BY Username";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPatients.DataSource = dt;
                    dgvPatients.Columns["UserID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patients: " + ex.Message);
                }
            }

        }

        // schedule 
        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
            ScheduleAppointmentForm scheduleForm = new ScheduleAppointmentForm();
            if (scheduleForm.ShowDialog() == DialogResult.OK)
            {
                LoadAppointments();
            }
        }
        // update appoitment
        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);
            UpdateAppointmentForm updateForm = new UpdateAppointmentForm(appointmentId);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                LoadAppointments();
            }
        }
        // cancel appointment
        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to cancel.");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);

            if (MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm Cancellation",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Appointments SET Status = 'Cancelled' WHERE AppointmentID = @AppointmentID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AppointmentID", appointmentId);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Appointment cancelled successfully.");
                        LoadAppointments();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cancelling appointment: " + ex.Message);
                    }
                }
            }
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to generate invoice.");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);
            GenerateInvoiceForm invoiceForm = new GenerateInvoiceForm(appointmentId);
            invoiceForm.ShowDialog();
        }

        private void secretaryDashboard_Load_1(object sender, EventArgs e)
        {

        }
    }
}
