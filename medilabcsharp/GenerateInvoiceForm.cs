using System;
using System.Data;
using System.Data.SqlClient;
using System.IO; // For FileStream  
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using medilabcsharp;
namespace MedicalCenter
{
    public partial class GenerateInvoiceForm : Form
    {
        private int appointmentId;
        private int invoiceId = 0; // Initialize as 0 (unsaved state)
        private decimal invoiceTotal = 0m;
        private int selectedInvoiceId = 0;
private decimal selectedInvoiceTotal = 0;
        private const string connectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";

        public GenerateInvoiceForm(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            LoadAppointmentData();
            LoadExistingInvoices();
            
        }

        private void LoadAppointmentData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT a.AppointmentID, p.Username AS PatientName, 
                               d.Username AS DoctorName, a.AppointmentDate, 
                               a.DurationMinutes, a.Reason
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
                    lblInvoiceTitle.Text = $"INVOICE FOR APPOINTMENT #{reader["AppointmentID"]}";
                    lblPatient.Text = reader["PatientName"].ToString();
                    lblDoctor.Text = reader["DoctorName"].ToString();
                    lblDate.Text = Convert.ToDateTime(reader["AppointmentDate"]).ToString("dd/MM/yyyy HH:mm");
                    lblDuration.Text = $"{reader["DurationMinutes"]} minutes";
                    txtNotes.Text = reader["Reason"].ToString();
                }
                reader.Close();
            }
        }

        // load already found bills 
        private void LoadExistingInvoices()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                           InvoiceID, 
                           CONVERT(varchar, InvoiceDate, 103) AS InvoiceDate,
                           TotalAmount,
                           Status
                           FROM Invoices
                           WHERE AppointmentID = @AppointmentID
                           ORDER BY InvoiceDate DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Configure DataGridView before binding
                    ConfigureInvoiceItemsGrid();

                    dgvInvoiceItems.DataSource = dt;

                    // Add color coding for status
                    //  dgvInvoiceItems.CellFormatting += DgvInvoiceItems_CellFormatting;
                    CalculateTotals();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoices: " + ex.Message);
            }
        }

     
        private void ConfigureInvoiceItemsGrid()
        {
            // Clear existing columns
            dgvInvoiceItems.Columns.Clear();

            // Add columns manually with proper configuration
            DataGridViewTextBoxColumn colInvoiceId = new DataGridViewTextBoxColumn();
            colInvoiceId.Name = "InvoiceID";
            colInvoiceId.HeaderText = "Invoice #";
            colInvoiceId.DataPropertyName = "InvoiceID";
            colInvoiceId.ReadOnly = true;
            dgvInvoiceItems.Columns.Add(colInvoiceId);

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "InvoiceDate";
            colDate.HeaderText = "Date";
            colDate.DataPropertyName = "InvoiceDate";
            colDate.ReadOnly = true;
            dgvInvoiceItems.Columns.Add(colDate);

            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn();
            colAmount.Name = "TotalAmount";
            colAmount.HeaderText = "Amount";
            colAmount.DataPropertyName = "TotalAmount";
            colAmount.DefaultCellStyle.Format = "C2";
            colAmount.ReadOnly = true;
            dgvInvoiceItems.Columns.Add(colAmount);

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.HeaderText = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.ReadOnly = true;
            dgvInvoiceItems.Columns.Add(colStatus);

            // Set selection mode
            dgvInvoiceItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceItems.MultiSelect = false;
        }
        private void CalculateRowTotal(int rowIndex)
        {
            int quantity = Convert.ToInt32(dgvInvoiceItems.Rows[rowIndex].Cells["Quantity"].Value);
            decimal unitPrice = Convert.ToDecimal(dgvInvoiceItems.Rows[rowIndex].Cells["UnitPrice"].Value);
            dgvInvoiceItems.Rows[rowIndex].Cells["Total"].Value = quantity * unitPrice;
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
            {
                // Skip the new row placeholder and rows without data
                if (!row.IsNewRow && row.Cells["TotalAmount"].Value != null)
                {
                    // Try to parse the TotalAmount value
                    if (decimal.TryParse(row.Cells["TotalAmount"].Value.ToString(), out decimal amount))
                    {
                        subtotal += amount;
                    }
                }
            }

            decimal taxRate = 0.10m; // 10% tax
            decimal taxAmount = subtotal * taxRate;
            decimal totalAmount = subtotal + taxAmount;

            lblSubtotal.Text = subtotal.ToString("C");
            lblTax.Text = taxAmount.ToString("C");
            lblTotal.Text = totalAmount.ToString("C");
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvInvoiceItems.SelectedRows)
                {
                    dgvInvoiceItems.Rows.Remove(row);
                }
                CalculateTotals();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one invoice item.");
                return;
            }

            SaveInvoiceToDatabase();
            GeneratePDFInvoice();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveInvoiceToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert invoice header
                    string invoiceQuery = @"INSERT INTO Invoices 
                         (AppointmentID, PatientID, DoctorID, InvoiceDate, 
                         DueDate, TotalAmount, TaxAmount, Status, Notes)
                         VALUES (@AppointmentID, @PatientID, @DoctorID, 
                         GETDATE(), DATEADD(day, 30, GETDATE()), 
                         @TotalAmount, @TaxAmount, 'Pending', @Notes);
                         SELECT SCOPE_IDENTITY();";

                    SqlCommand invoiceCommand = new SqlCommand(invoiceQuery, connection, transaction);

                    // Get patient and doctor IDs
                    string idsQuery = @"SELECT PatientID, DoctorID FROM Appointments 
                          WHERE AppointmentID = @AppointmentID";
                    SqlCommand idsCommand = new SqlCommand(idsQuery, connection, transaction);
                    idsCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    SqlDataReader reader = idsCommand.ExecuteReader();
                    reader.Read();
                    int patientId = reader.GetInt32(0);
                    int doctorId = reader.GetInt32(1);
                    reader.Close();

                    // Add all parameters
                    invoiceCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    invoiceCommand.Parameters.AddWithValue("@PatientID", patientId);
                    invoiceCommand.Parameters.AddWithValue("@DoctorID", doctorId);

                    // Add the missing TotalAmount parameter
                    invoiceCommand.Parameters.AddWithValue("@TotalAmount",
                        decimal.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency));

                    invoiceCommand.Parameters.AddWithValue("@TaxAmount",
                        decimal.Parse(lblTax.Text, System.Globalization.NumberStyles.Currency));
                    invoiceCommand.Parameters.AddWithValue("@Notes", txtNotes.Text);

                    int invoiceId = Convert.ToInt32(invoiceCommand.ExecuteScalar());
                    transaction.Commit();
                    MessageBox.Show("Invoice generated successfully!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving invoice: " + ex.Message);
                }
            }
        }
        //generate PDF
        private void GeneratePDFInvoice()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Invoice_Appt_{appointmentId}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create document and PDF writer
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 50, 50, 25, 25);
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(
                        document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    document.Open();

                    // Font definitions
                    iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(
                        iTextSharp.text.FontFactory.HELVETICA_BOLD, 18);

                    iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(
                        iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);

                    iTextSharp.text.Font normalFont = iTextSharp.text.FontFactory.GetFont(
                        iTextSharp.text.FontFactory.HELVETICA, 10);

                    iTextSharp.text.Font boldFont = iTextSharp.text.FontFactory.GetFont(
                        iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);

                    // Add title
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(
                        "MEDICAL CENTER INVOICE", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(title);

                    // Add invoice details
                    document.Add(new iTextSharp.text.Paragraph("\n"));

                    iTextSharp.text.pdf.PdfPTable detailsTable = new iTextSharp.text.pdf.PdfPTable(2);
                    detailsTable.WidthPercentage = 100;

                    AddDetailCell(detailsTable, "Invoice Number:", $"INV-{appointmentId}-{DateTime.Now:yyyyMMdd}", boldFont, normalFont);
                    AddDetailCell(detailsTable, "Date Issued:", DateTime.Now.ToString("dd/MM/yyyy"), boldFont, normalFont);
                    AddDetailCell(detailsTable, "Patient:", lblPatient.Text, boldFont, normalFont);
                    AddDetailCell(detailsTable, "Doctor:", lblDoctor.Text, boldFont, normalFont);
                    AddDetailCell(detailsTable, "Appointment Date:", lblDate.Text, boldFont, normalFont);

                    document.Add(detailsTable);

                    // Add items table
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                    iTextSharp.text.pdf.PdfPTable itemsTable = new iTextSharp.text.pdf.PdfPTable(4);
                    itemsTable.WidthPercentage = 100;

                    // Header row
                   // AddTableHeaderCell(itemsTable, "Description", headerFont);
                 //   AddTableHeaderCell(itemsTable, "Quantity", headerFont);
                  //  AddTableHeaderCell(itemsTable, "Unit Price", headerFont);
                  //  AddTableHeaderCell(itemsTable, "Total", headerFont);

                    // Add invoice items
                    foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
                    {
                       
                           
                          //  AddTableCell(itemsTable, row.Cells["Quantity"].Value.ToString(), normalFont);
                           // AddTableCell(itemsTable, row.Cells["UnitPrice"].Value.ToString(), normalFont);
                          //  AddTableCell(itemsTable, row.Cells["Total"].Value.ToString(), normalFont);
                        
                    }

                    document.Add(itemsTable);

                    // Add totals
                    document.Add(new iTextSharp.text.Paragraph("\n"));
                    iTextSharp.text.pdf.PdfPTable totalsTable = new iTextSharp.text.pdf.PdfPTable(2);
                    totalsTable.WidthPercentage = 50;
                    totalsTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;

                    AddTotalCell(totalsTable, "Subtotal:", lblSubtotal.Text, boldFont, normalFont);
                    AddTotalCell(totalsTable, "Tax:", lblTax.Text, boldFont, normalFont);
                  //  AddTotalCell(totalsTable, "Total:", lblTotal.Text, boldFont, normalFont);

                    document.Add(totalsTable);

                    // Add notes if available
                    if (!string.IsNullOrWhiteSpace(txtNotes.Text))
                    {
                        document.Add(new iTextSharp.text.Paragraph("\nNotes:", boldFont));
                        document.Add(new iTextSharp.text.Paragraph(txtNotes.Text, normalFont));
                    }

                    document.Close();

                    MessageBox.Show($"PDF invoice successfully generated at:\n{saveFileDialog.FileName}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating PDF: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Updated helper methods with font parameters
        private void AddDetailCell(iTextSharp.text.pdf.PdfPTable table, string label, string value,
            iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(label, labelFont)));
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(value, valueFont)));
        }

        private void AddTableHeaderCell(iTextSharp.text.pdf.PdfPTable table, string text, iTextSharp.text.Font font)
        {
            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            table.AddCell(cell);
        }

        private void AddTableCell(iTextSharp.text.pdf.PdfPTable table, string text, iTextSharp.text.Font font)
        {
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, font)));
        }

        private void AddTotalCell(iTextSharp.text.pdf.PdfPTable table, string label, string value,
            iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(label, labelFont)));
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(value, valueFont)));
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void GenerateInvoiceForm_Load(object sender, EventArgs e)
        {

        }
        private void btnRecordPayment_Click(object sender, EventArgs e)
{
    if (dgvInvoiceItems.SelectedRows.Count == 0)
    {
        MessageBox.Show("Please select an invoice first.");
        return;
    }

    DataGridViewRow selectedRow = dgvInvoiceItems.SelectedRows[0];
    int selectedInvoiceId = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
    decimal invoiceTotal = Convert.ToDecimal(selectedRow.Cells["TotalAmount"].Value);
    string currentStatus = selectedRow.Cells["Status"].Value.ToString();

    // Only allow payment for pending or overdue invoices
    if (currentStatus != "Pending" && currentStatus != "Overdue")
    {
        MessageBox.Show("You can only record payments for Pending or Overdue invoices.");
        return;
    }

    using (PaymentDialog paymentDialog = new PaymentDialog(selectedInvoiceId, invoiceTotal))
    {
        if (paymentDialog.ShowDialog() == DialogResult.OK)
        {
            // Update the status in the grid
            selectedRow.Cells["Status"].Value = "Paid";
            MessageBox.Show($"Payment of {paymentDialog.PaymentAmount:C} recorded!");
            
            // Optional: Refresh the grid from database
            LoadExistingInvoices();
        }
    }
}

        private void btnRecordPayment_Click_1(object sender, EventArgs e)
        {

        }
    }
}