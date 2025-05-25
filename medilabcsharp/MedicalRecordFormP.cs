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
    public partial class MedicalRecordFormP : Form
    {
        private int patientId;
        private const string ConnectionString =
            @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        public MedicalRecordFormP(int patientId)
        {
            InitializeComponent();
            this.patientId = CurrentUser.Id;
            LoadMedicalHistory();
        }

        private void MedicalRecordFormP_Load(object sender, EventArgs e)
        {

        }
        private void LoadMedicalHistory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT 
                                mr.ConsultationDate,
                                u.FirstName + ' ' + u.LastName AS DoctorName,
                                mr.Diagnosis,
                                mr.Treatment,
                                mr.Notes,
                                mr.FollowUpDate
                             FROM MedicalRecords mr
                             JOIN Users u ON mr.DoctorID = u.UserID
                             WHERE mr.PatientID = @PatientID
                             ORDER BY mr.ConsultationDate DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PatientID", patientId);

                    connection.Open();

                    // Création d'un DataTable pour stocker les résultats
                    DataTable medicalHistory = new DataTable();
                    medicalHistory.Load(command.ExecuteReader());

                    // Configuration du DataGridView
                    dataGridViewMedicalRecords.DataSource = medicalHistory;
                    dataGridViewMedicalRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Formatage des colonnes
                    if (dataGridViewMedicalRecords.Columns.Count > 0)
                    {
                        dataGridViewMedicalRecords.Columns["ConsultationDate"].HeaderText = "Date Consultation";
                        dataGridViewMedicalRecords.Columns["DoctorName"].HeaderText = "Médecin";
                        dataGridViewMedicalRecords.Columns["Diagnosis"].HeaderText = "Diagnostic";
                        dataGridViewMedicalRecords.Columns["Treatment"].HeaderText = "Traitement";
                        dataGridViewMedicalRecords.Columns["Notes"].HeaderText = "Notes";
                        dataGridViewMedicalRecords.Columns["FollowUpDate"].HeaderText = "Prochaine Visite";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de chargement du dossier médical: {ex.Message}",
                              "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MedicalRecordFormP_Load_1(object sender, EventArgs e)
        {

        }
    }
}
