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
using System.Xml;

namespace medilabcsharp
{
    public partial class AddMedicalDocumentForm : Form
    {
        private const string ConnectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        private int patientId;
        private int doctorId;
        private string selectedFilePath = string.Empty;


        public AddMedicalDocumentForm(int patientId, int doctorId)
        {
            InitializeComponent();
            this.patientId = patientId;
            this.doctorId = doctorId;
            btnBrowse.Click += btnBrowse_Click;

            // Populate document type dropdown
            cmbDocumentType.Items.AddRange(new string[]
            {
            "Prescription",
            "test results",
            "Prescription"

            });
            cmbDocumentType.SelectedIndex = 0;
        }

        private void AddMedicalDocumentForm_Load(object sender, EventArgs e)
        {

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            openFileDialog.Title = "Sélectionner un document médical";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Validate PDF file
                if (Path.GetExtension(openFileDialog.FileName).ToLower() != ".pdf")
                {
                    MessageBox.Show("Seuls les fichiers PDF sont acceptés.", "Format invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedFilePath = openFileDialog.FileName;
                txtFileName.Text = Path.GetFileName(selectedFilePath);
                txtFilePath.Text = GenerateDocumentPath(selectedFilePath);
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {

        }
        private string GenerateDocumentPath(string sourcePath)
        {
            // Create patient-specific directory if it doesn't exist
            string patientDir = Path.Combine(Application.StartupPath, "MedicalDocuments", patientId.ToString());
            if (!Directory.Exists(patientDir))
            {
                Directory.CreateDirectory(patientDir);
            }

            // Generate unique filename
            string fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(sourcePath)}";
            return Path.Combine(patientDir, fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Input validation
            if (string.IsNullOrWhiteSpace(cmbDocumentType.Text))
            {
                MessageBox.Show("Veuillez sélectionner un type de document.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                MessageBox.Show("Veuillez sélectionner un fichier PDF.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Veuillez entrer une description.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get the most recent medical record for this patient-doctor pair
                int recordId = GetLatestMedicalRecordId();

                if (recordId == -1)
                {
                    MessageBox.Show("Aucun dossier médical trouvé. Veuillez d'abord créer une consultation.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Copy file to application directory
                string destPath = txtFilePath.Text;
                File.Copy(selectedFilePath, destPath, true);

                // Save to database
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query = @"INSERT INTO MedicalDocuments 
                                (RecordID, DocumentType, FileName, FilePath, Description)
                              VALUES 
                                (@recordId, @docType, @fileName, @filePath, @description)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recordId", recordId);
                    cmd.Parameters.AddWithValue("@docType", cmbDocumentType.Text);
                    cmd.Parameters.AddWithValue("@fileName", txtFileName.Text);
                    cmd.Parameters.AddWithValue("@filePath", destPath);
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du document: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int GetLatestMedicalRecordId()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT TOP 1 RecordID 
                          FROM MedicalRecords 
                          WHERE PatientID = @patientId AND DoctorID = @doctorId
                          ORDER BY ConsultationDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", patientId);
                cmd.Parameters.AddWithValue("@doctorId", doctorId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }      
}
