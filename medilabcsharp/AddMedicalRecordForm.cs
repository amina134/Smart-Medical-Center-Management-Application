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
    public partial class AddMedicalRecordForm : Form
    {
        private const string ConnectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";
        private int patientId;
        private int doctorId;
        public AddMedicalRecordForm(int patientId, int doctorId)
        {
            InitializeComponent();

            this.patientId = patientId;
            this.doctorId = doctorId;
        }

        private void AddMedicalRecordForm_Load(object sender, EventArgs e)
        {

        }
        private void chkFollowUp_CheckedChanged(object sender, EventArgs e)
        {
            dtpFollowUp.Enabled = chkFollowUp.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        string query = @"INSERT INTO MedicalRecords 
                                      (PatientID, DoctorID, ConsultationDate, 
                                       Diagnosis, Treatment, Notes, FollowUpDate)
                                      VALUES 
                                      (@patientId, @doctorId, @consultDate,
                                       @diagnosis, @treatment, @notes, @followUp)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@patientId", patientId);
                        cmd.Parameters.AddWithValue("@doctorId", doctorId);
                        cmd.Parameters.AddWithValue("@consultDate", dtpConsultation.Value);
                        cmd.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text);
                        cmd.Parameters.AddWithValue("@treatment", txtTreatment.Text);
                        cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
                        cmd.Parameters.AddWithValue("@followUp",
                            chkFollowUp.Checked ? dtpFollowUp.Value : (object)DBNull.Value);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving record: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Diagnosis is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dtpFollowUp_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
