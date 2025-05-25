using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Configuration;
namespace medilabcsharp
{
    public partial class NewAppointmentForm : Form
    {
        private int patientId;
        private const string ConnectionString =
            @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        private string SmtpServer => ConfigurationManager.AppSettings["SmtpServer"];
        private int SmtpPort => int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        private string SmtpUsername => ConfigurationManager.AppSettings["SmtpUsername"];
        private string SmtpPassword => ConfigurationManager.AppSettings["SmtpPassword"];
        private bool EnableSsl => bool.Parse(ConfigurationManager.AppSettings["EnableSsl"]);
        private string FromEmail => ConfigurationManager.AppSettings["FromEmail"];
        private string FromName => ConfigurationManager.AppSettings["FromName"];
        public NewAppointmentForm(int patientId)
        {
            InitializeComponent();
            this.patientId = CurrentUser.Id;
            WireUpEvents();
            LoadSpecialties();
        }

        private void WireUpEvents()
        {
            this.specialiteCombo.SelectedIndexChanged += SpecialiteChanged;
            this.rdvCalendar.DateChanged += DateSelected;
            this.confirmButton.Click += ConfirmAppointment;
        }
        //

        private bool AppointmentExists(int doctorId, DateTime appointmentDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT 1 FROM Appointments 
                          WHERE DoctorID = @DoctorID 
                          AND CONVERT(DATE, AppointmentDate) = @AppointmentDate
                          AND Status != 'Cancelled'";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DoctorID", doctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate.Date);

                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidAppointmentDate(DateTime date)
        {
            // Check if date is at least 24 hours in the future
            if (date < DateTime.Now.AddHours(24))
            {
                MessageBox.Show("Appointments must be scheduled at least 24 hours in advance.");
                return false;
            }

            // Check if date is not in the past
            if (date.Date < DateTime.Today)
            {
                MessageBox.Show("Cannot schedule appointments in the past.");
                return false;
            }

            // Check if date is not too far in the future (optional)
            if (date.Year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Cannot schedule appointments more than one year in advance.");
                return false;
            }

            return true;
        }

        private void NewAppointmentForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadSpecialties()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT DISTINCT specialization FROM Users WHERE Role = 'Doctor'";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    specialiteCombo.Items.Clear();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            specialiteCombo.Items.Add(reader["specialization"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specialties: {ex.Message}");
                // Fallback to default specialties
                specialiteCombo.Items.AddRange(new object[] {
                    "Cardiology",
                    "Pediatrics",
                    "Dermatology",
                    "General Medicine"
                });
            }
        }

        private void SpecialiteChanged(object sender, EventArgs e)
        {
            if (specialiteCombo.SelectedItem == null) return;

            medecinCombo.Enabled = true;
            medecinCombo.Items.Clear();
            medecinCombo.SelectedIndex = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT UserID, firstName + ' ' + lastName AS DoctorName 
                                   FROM Users 
                                   WHERE Role = 'Doctor' AND specialization = @Specialty";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Specialty", specialiteCombo.SelectedItem.ToString());

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        medecinCombo.Items.Add(new DoctorItem(
                            reader["DoctorName"].ToString(),
                            Convert.ToInt32(reader["UserID"])
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}");
            }
        }

        private void DateSelected(object sender, DateRangeEventArgs e)
        {
            if (medecinCombo.SelectedItem == null) return;

            DateTime selectedDate = rdvCalendar.SelectionStart.Date;

            // Don't allow selecting past dates
            if (selectedDate < DateTime.Today)
            {
                MessageBox.Show("Cannot select past dates.");
                rdvCalendar.SelectionStart = DateTime.Today;
                return;
            }

            creneauxList.Items.Clear();

            // Get selected doctor
            var selectedDoctor = (DoctorItem)medecinCombo.SelectedItem;

            // Get available time slots (filtering out past times for today)
            List<string> availableSlots = GetAvailableTimeSlots(selectedDate, selectedDoctor.Id);

            creneauxList.Items.AddRange(availableSlots.ToArray());
        }

        private List<string> GetAvailableTimeSlots(DateTime date, int doctorId)
        {
            List<string> availableSlots = new List<string>();
            DateTime now = DateTime.Now;

            // Generate time slots from 9AM to 4PM in 30-minute increments
            DateTime startTime = date.Date.AddHours(9);
            DateTime endTime = date.Date.AddHours(16);

            // If selecting today, start from current time + 24 hours
            if (date.Date == DateTime.Today)
            {
                startTime = now.AddHours(24);
                // Round up to nearest 30 minutes
                if (startTime.Minute < 30 && startTime.Minute != 0)
                {
                    startTime = startTime.AddMinutes(30 - startTime.Minute);
                }
                else if (startTime.Minute > 30)
                {
                    startTime = startTime.AddMinutes(60 - startTime.Minute);
                }
            }

            while (startTime < endTime)
            {
                // Check if this slot is already booked
                if (!IsTimeSlotBooked(doctorId, startTime))
                {
                    availableSlots.Add($"{startTime:HH:mm} - {startTime.AddMinutes(30):HH:mm}");
                }
                startTime = startTime.AddMinutes(30);
            }

            return availableSlots;
        }

        private bool IsTimeSlotBooked(int doctorId, DateTime startTime)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT 1 FROM Appointments 
                          WHERE DoctorID = @DoctorID 
                          AND AppointmentDate BETWEEN @StartTime AND @EndTime
                          AND Status != 'Cancelled'";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DoctorID", doctorId);
                    command.Parameters.AddWithValue("@StartTime", startTime);
                    command.Parameters.AddWithValue("@EndTime", startTime.AddMinutes(30));

                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
            }
            catch
            {
                return false;
            }
        }


        private void ConfirmAppointment(object sender, EventArgs e)
        {
            if (!ValidateAppointment()) return;

            if (ValidateAppointment())
            {
                try
                {
                    // Get selected time slot
                    string[] timeParts = creneauxList.SelectedItem.ToString().Split('-');
                    DateTime appointmentDate = rdvCalendar.SelectionStart.Date.Add(
                        TimeSpan.Parse(timeParts[0].Trim())
                    );
                    if (!IsValidAppointmentDate(appointmentDate)) return;


                    // Get selected doctor
                    var selectedDoctor = (DoctorItem)medecinCombo.SelectedItem;
                    if (AppointmentExists(selectedDoctor.Id, appointmentDate))
                    {
                        MessageBox.Show("This time slot is already booked. Please choose another time.");
                        return;
                    }
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        string query = @"INSERT INTO Appointments 
                                      (PatientID, DoctorID, AppointmentDate, Status, Reason)
                                      VALUES (@PatientID, @DoctorID, @AppointmentDate, 'Scheduled', @Reason)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@PatientID", patientId);
                        command.Parameters.AddWithValue("@DoctorID", selectedDoctor.Id);
                        command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                        command.Parameters.AddWithValue("@Reason", "New appointment"); // You can add a reason field to your form

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    SendAppointmentEmail(
                      recipientEmail: GetPatientEmail(patientId), // Implement this method
                      patientName: GetPatientName(patientId),     // Implement this method
                      appointmentDate: appointmentDate,
                      doctorName: selectedDoctor.Name
      );
                    TestEmailSettings();

                    MessageBox.Show("Appointment confirmed!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating appointment: {ex.Message}");
                }
            }
        }

        private bool ValidateAppointment()
        {
            if (medecinCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a doctor");
                return false;
            }

            if (creneauxList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a time slot");
                return false;
            }

            return true;
        }

        // Helper class to store doctor information in combobox
        private class DoctorItem
        {
            public string Name { get; }
            public int Id { get; }

            public DoctorItem(string name, int id)
            {
                Name = name;
                Id = id;
            }

            public override string ToString() => Name;
        }

        public void TestEmailSettings()
        {
            try
            {
                // Get settings
                string server = ConfigurationManager.AppSettings["SmtpServer"];
                int port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
                string username = ConfigurationManager.AppSettings["SmtpUsername"];
                string password = ConfigurationManager.AppSettings["SmtpPassword"];
                bool ssl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"]);
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"];

                // Display settings being used (for debugging)
                string debugInfo = $"Trying to send with:\nServer: {server}:{port}\nUser: {username}\nSSL: {ssl}";
                Console.WriteLine(debugInfo); // Check Output window

                using (var client = new SmtpClient(server, port))
                {
                    client.EnableSsl = ssl;
                    client.Credentials = new NetworkCredential(username, password);
                    client.Timeout = 5000; // 5 second timeout

                    // Create test message
                    var message = new MailMessage
                    {
                        From = new MailAddress(fromEmail),
                        Subject = "Medical Center Test Email",
                        Body = "This is a test email from the Medical Center system.",
                        IsBodyHtml = false
                    };
                    message.To.Add("aminakouni14@gmail.com"); // Send to yourself

                    // Add event handler to track progress
                    client.SendCompleted += (s, e) =>
                    {
                        if (e.Error != null)
                            MessageBox.Show($"Send failed: {e.Error.Message}");
                        else if (e.Cancelled)
                            MessageBox.Show("Send was cancelled");
                        else
                            MessageBox.Show("Email sent successfully!");
                    };

                    // Try sending
                    client.Send(message);
                    MessageBox.Show("Email sent successfully!");
                }
            }
            catch (Exception ex)
            {
                // Show detailed error
                string errorMessage = $"Failed to send email:\n\n{ex.Message}";
                if (ex.InnerException != null)
                    errorMessage += $"\n\nInner exception:\n{ex.InnerException.Message}";

                MessageBox.Show(errorMessage, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendAppointmentEmail(string recipientEmail, string patientName,
                                DateTime appointmentDate, string doctorName)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
                {
                    client.EnableSsl = EnableSsl;
                    client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);

                    MailMessage message = new MailMessage
                    {
                        From = new MailAddress(FromEmail, FromName),
                        Subject = $"[Centre Médical] Confirmation de rendez-vous",
                        Body = $@"Bonjour {patientName},

                                Votre rendez-vous avec le Dr. {doctorName} est confirmé pour :
                                📅 {appointmentDate:dddd dd MMMM yyyy}
                                ⏰ {appointmentDate:HH:mm}

                                Adresse : [Tunis]
                                Contact : [99551402]

                                Merci de venir 10 minutes avant l'heure du rendez-vous.

                                Cordialement,
                                L'équipe du Centre Médical",
                        IsBodyHtml = false
                    };
                    message.To.Add(recipientEmail);
                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't prevent appointment confirmation
                Console.WriteLine($"Erreur d'envoi d'email: {ex.Message}");
            }
        }


        private string GetPatientEmail(int patientId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT email FROM Users WHERE UserID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", patientId);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result?.ToString() ?? string.Empty; // Return empty string if null
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de l'email: {ex.Message}");
                return string.Empty;
            }
        }

        private string GetPatientName(int patientId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT firstName + ' ' + lastName FROM Users WHERE UserID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", patientId);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result?.ToString() ?? "Patient"; // Default to "Patient" if null
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération du nom: {ex.Message}");
                return "Patient";
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

        }
    }
}