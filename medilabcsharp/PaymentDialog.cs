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
    public partial class PaymentDialog : Form
    {
        private readonly int invoiceId;
        private readonly decimal invoiceTotal;
        private const string connectionString =
        @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";

        public decimal PaymentAmount { get; private set; }
        public string PaymentMethod => cmbMethod.SelectedItem.ToString();
        public DateTime PaymentDate => dtpDate.Value;
        public PaymentDialog(int invoiceId, decimal invoiceTotal)
        {
            InitializeComponent();
            this.invoiceId = invoiceId;
            this.invoiceTotal = invoiceTotal;
            InitializePaymentDialog();
        }

        private void PaymentDialog_Load(object sender, EventArgs e)
        {

        }
        private void InitializePaymentDialog()
        {
            // Set up initial values
            numAmount.Maximum = invoiceTotal;
            numAmount.Value = invoiceTotal;
            dtpDate.Value = DateTime.Today;
            cmbMethod.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Please enter a valid payment amount.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PaymentAmount = numAmount.Value;
                SavePaymentToDatabase();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording payment:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePaymentToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert payment record
                        string paymentQuery = @"INSERT INTO Payments 
                                              (InvoiceID, Amount, PaymentDate, PaymentMethod)
                                              VALUES (@InvoiceID, @Amount, @Date, @Method)";

                        SqlCommand paymentCmd = new SqlCommand(paymentQuery, connection, transaction);
                        paymentCmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                        paymentCmd.Parameters.AddWithValue("@Amount", PaymentAmount);
                        paymentCmd.Parameters.AddWithValue("@Date", PaymentDate);
                        paymentCmd.Parameters.AddWithValue("@Method", PaymentMethod);
                        paymentCmd.ExecuteNonQuery();

                        // 2. Update invoice status
                        string statusQuery = @"UPDATE Invoices SET Status = 
                                             CASE WHEN (SELECT SUM(Amount) FROM Payments 
                                             WHERE InvoiceID = @InvoiceID) >= TotalAmount
                                             THEN 'Paid' ELSE 'Partially Paid' END
                                             WHERE InvoiceID = @InvoiceID";

                        SqlCommand statusCmd = new SqlCommand(statusQuery, connection, transaction);
                        statusCmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                        statusCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }
    }
}
