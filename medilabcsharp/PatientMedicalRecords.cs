using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilabcsharp
{
    public partial class PatientMedicalRecords : Form
    {
        private const string ConnectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";

        private int patientId;
        private int doctorId;
        public PatientMedicalRecords(int patientId, int doctorId)
        {
            InitializeComponent();
            this.patientId = patientId;
            this.doctorId = doctorId;
            LoadPatientInfo();
            LoadMedicalRecords();
            LoadMedicalDocuments();
        }

        private void PatientMedicalRecords_Load(object sender, EventArgs e)
        {

        }
        private void LoadPatientInfo()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT FirstName, LastName, Email FROM Users WHERE UserID = @patientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", patientId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblPatientName.Text = $"{reader["FirstName"]} {reader["LastName"]}";
                    lblPatientEmail.Text = reader["Email"].ToString();
                }
                reader.Close();
            }
        }

        private void LoadMedicalRecords()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT 
                            mr.RecordID,
                            FORMAT(mr.ConsultationDate, 'yyyy-MM-dd HH:mm') AS ConsultationDate,
                            u.FirstName + ' ' + u.LastName AS Doctor,
                            mr.Diagnosis,
                            mr.Treatment,
                            mr.Notes,
                            FORMAT(mr.FollowUpDate, 'yyyy-MM-dd') AS FollowUpDate
                          FROM MedicalRecords mr
                          JOIN Users u ON mr.DoctorID = u.UserID
                          WHERE mr.PatientID = @patientId
                          ORDER BY mr.ConsultationDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@patientId", patientId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewRecords.DataSource = dt;
                dataGridViewRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadMedicalDocuments()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT 
                              d.DocumentID,
                              d.DocumentType,
                              d.FileName,
                              d.FilePath,
                              d.Description,
                              FORMAT(d.UploadDate, 'yyyy-MM-dd') AS UploadDate
                            FROM MedicalDocuments d
                            JOIN MedicalRecords mr ON d.RecordID = mr.RecordID
                            WHERE mr.PatientID = @patientId
                            ORDER BY d.UploadDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@patientId", patientId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewDocuments.DataSource = dt;
                dataGridViewDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnViewDocument_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocuments.SelectedRows.Count > 0)
            {
                string filePath = dataGridViewDocuments.SelectedRows[0].Cells["FilePath"].Value.ToString();

                try
                {
                    // Check if the file is a PDF
                    if (!filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Only PDF documents are supported.", "Invalid Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Path to Adobe Acrobat executable (adjust if needed)
                    string acrobatPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";

                    // Verify Adobe exists
                    if (!File.Exists(acrobatPath))
                    {
                        MessageBox.Show("Adobe Acrobat is not installed.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Launch Adobe with the PDF file
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = acrobatPath,
                        Arguments = $"\"{filePath}\"", // Quotes handle paths with spaces
                        UseShellExecute = false
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open PDF: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addDocument_Click(object sender, EventArgs e)
        {
            // Create and show the add document form
            using (AddMedicalDocumentForm addForm = new AddMedicalDocumentForm(patientId, doctorId))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh documents after adding
                    LoadMedicalDocuments();
                }
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            using (AddMedicalRecordForm addForm = new AddMedicalRecordForm(patientId, doctorId))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh records after adding
                    LoadMedicalRecords();
                }
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the medical records DataGridView
            if (dataGridViewRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the RecordID from the selected row
            int recordId = Convert.ToInt32(dataGridViewRecords.SelectedRows[0].Cells["RecordID"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this medical record? This action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        // First delete any associated documents
                        string deleteDocumentsQuery = @"DELETE FROM MedicalDocuments 
                                             WHERE RecordID = @recordId";

                        SqlCommand deleteDocumentsCmd = new SqlCommand(deleteDocumentsQuery, conn);
                        deleteDocumentsCmd.Parameters.AddWithValue("@recordId", recordId);

                        // Then delete the record
                        string deleteRecordQuery = @"DELETE FROM MedicalRecords 
                                          WHERE RecordID = @recordId";

                        SqlCommand deleteRecordCmd = new SqlCommand(deleteRecordQuery, conn);
                        deleteRecordCmd.Parameters.AddWithValue("@recordId", recordId);

                        conn.Open();

                        // Use transaction to ensure both deletions succeed or fail together
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            deleteDocumentsCmd.Transaction = transaction;
                            deleteRecordCmd.Transaction = transaction;

                            deleteDocumentsCmd.ExecuteNonQuery();
                            deleteRecordCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Record deleted successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the records grid
                            LoadMedicalRecords();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteDocument_Click(object sender, EventArgs e)
        {
            // Check if a document is selected
            if (dataGridViewDocuments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a document to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get document details
            int documentId = Convert.ToInt32(dataGridViewDocuments.SelectedRows[0].Cells["DocumentID"].Value);
            string filePath = dataGridViewDocuments.SelectedRows[0].Cells["FilePath"].Value.ToString();
            string fileName = dataGridViewDocuments.SelectedRows[0].Cells["FileName"].Value.ToString();

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to permanently delete '{fileName}'?\nThis action cannot be undone.",
                "Confirm Document Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // First delete from database
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        string query = @"DELETE FROM MedicalDocuments 
                              WHERE DocumentID = @documentId";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@documentId", documentId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // Then delete physical file
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Warning: The physical file was not found.", "File Missing",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    MessageBox.Show("Document deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh documents list
                    LoadMedicalDocuments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting document: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
