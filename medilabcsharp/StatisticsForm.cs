using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ScottPlot.WinForms;
using ScottPlot;
using medilabcsharp;


namespace MedicalCenter
{
    public partial class StatisticsForm : Form
    {
        private const string ConnectionString =
          @"Server=LAPTOP-NBIE2FN7\SQLEXPRESS;
              Database=CentreMedical;
              User Id=amina;
              Password=aminakounieya14;
              TrustServerCertificate=True;";

        private FormsPlot formsPlot1;

        public StatisticsForm()
        {
            InitializeComponent();
            InitializeComponents();
            LoadSpecialties();
            this.WindowState = FormWindowState.Maximized;

            dtpEndDate.Value = DateTime.Today;
        }

        private void InitializeComponents()
        {
            // Initialize ScottPlot forms plot
            this.formsPlot1 = new FormsPlot();
            this.formsPlot1.Dock = DockStyle.Bottom;
            this.formsPlot1.Height = 390;
            this.Controls.Add(this.formsPlot1);

            // Initialize DataGridView
            dgvDoctorStats.AutoGenerateColumns = true;
            dgvDoctorStats.AllowUserToAddRows = false;
            dgvDoctorStats.ReadOnly = true;
            dgvDoctorStats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadSpecialties()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT specialization FROM Users WHERE Role = 'Doctor'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbSpecialty.DataSource = dt;
                    cmbSpecialty.DisplayMember = "specialization";
                    cmbSpecialty.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specialties: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.",
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                GenerateDoctorStatistics();
                CreatePieChart((DataTable)dgvDoctorStats.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating statistics: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void GenerateDoctorStatistics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        u.UserID, 
                        u.firstName + ' ' + u.lastName AS DoctorName,
                        ISNULL(u.specialization, 'General') AS Specialty,
                        COUNT(a.AppointmentID) AS ConsultationCount,
                        ISNULL(AVG(a.DurationMinutes), 0) AS AvgDuration
                    FROM Users u
                    LEFT JOIN Appointments a ON u.UserID = a.DoctorID 
                        AND a.Status = 'Completed'
                        AND a.AppointmentDate BETWEEN @StartDate AND @EndDate
                    WHERE u.Role = 'Doctor'
                    GROUP BY u.UserID, u.firstName, u.lastName, u.specialization
                    ORDER BY ConsultationCount DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1));

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No completed appointments found for selected period.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvDoctorStats.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor stats: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePieChart(DataTable data)
        {
            // Group by specialty
            var specialtyData = data.AsEnumerable()
                .GroupBy(row => row.Field<string>("Specialty"))
                .Select(g => new { Specialty = g.Key, Count = g.Sum(row => row.Field<int>("ConsultationCount")) })
                .OrderByDescending(x => x.Count)
                .ToList();

            // Clear previous plot
            formsPlot1.Plot.Clear();



            // Prepare data
            double[] values = specialtyData.Select(x => (double)x.Count).ToArray();
            string[] labels = specialtyData.Select(x => x.Specialty).ToArray();

            // Create pie chart
            var pie = formsPlot1.Plot.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowLabels = true;
            pie.ShowValues = true;
            pie.ShowPercentages = true;
            pie.Explode = true;
            pie.DonutSize = 0;  // Set to > 0 for a donut chart
            formsPlot1.Plot.Layout(padding: 0);
            // Configure legend
            formsPlot1.Plot.Legend(true, ScottPlot.Alignment.LowerRight);

            pie.Size = 1.12;

            // Plot styling - these work in v4
            formsPlot1.Plot.Style(figureBackground: System.Drawing.Color.White);
            formsPlot1.Plot.Grid(false);

            // Refresh the plot
            formsPlot1.Refresh();

            // Save to PNG file
            formsPlot1.Plot.SaveFig("myChart.png", 800, 600);
        }
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvDoctorStats.Rows.Count == 0)
            {
                MessageBox.Show("No data to export. Please generate statistics first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"MedicalStatistics_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CreatePdfDocument(saveDialog.FileName);
                    MessageBox.Show("PDF exported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting PDF: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreatePdfDocument(string filePath)
        {
            Document document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
            PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(filePath, System.IO.FileMode.Create));

            document.Open();

            // Add title and date range
            AddTitleSection(document);

            // Add doctor statistics table
            AddDoctorStatisticsTable(document);

            // Add chart image
            AddChartImage(document);

            document.Close();
        }

        private void AddTitleSection(Document document)
        {
            Paragraph title = new Paragraph("Medical Center - Consultation Statistics Report",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            Paragraph dateRange = new Paragraph($"\nPeriod: {dtpStartDate.Value:d} to {dtpEndDate.Value:d}",
                FontFactory.GetFont(FontFactory.HELVETICA, 12));
            dateRange.Alignment = Element.ALIGN_CENTER;
            document.Add(dateRange);

            document.Add(new Paragraph("\n"));
        }

        private void AddDoctorStatisticsTable(Document document)
        {
            PdfPTable table = new PdfPTable(dgvDoctorStats.Columns.Count);
            table.WidthPercentage = 100;

            // Add headers
            foreach (DataGridViewColumn column in dgvDoctorStats.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD)));
                cell.BackgroundColor = new BaseColor(220, 220, 220);
                table.AddCell(cell);
            }

            // Add data
            foreach (DataGridViewRow row in dgvDoctorStats.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(cell.Value?.ToString() ?? "");
                }
            }

            document.Add(new Paragraph("Doctor Consultation Statistics:",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
            document.Add(table);
            document.Add(new Paragraph("\n"));
        }

        private void AddChartImage(Document document)
        {
            // Save plot as temporary image
            string tempImagePath = System.IO.Path.GetTempFileName() + ".png";

            // Save the plot as a PNG file (v5 syntax)
            formsPlot1.plt.SaveFig("myChart.png", 800, 600);
            // Add to PDF
            iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(tempImagePath);
            chartImage.ScaleToFit(document.PageSize.Width - 20, document.PageSize.Height / 2);
            chartImage.Alignment = Element.ALIGN_CENTER;

            document.Add(new Paragraph("Consultation Trends:",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)));
            document.Add(chartImage);

            // Clean up
            System.IO.File.Delete(tempImagePath);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dgvDoctorStats.DataSource == null)
            {
                MessageBox.Show("Please generate statistics first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string specialty = cmbSpecialty.Text;
                if (!string.IsNullOrEmpty(specialty))
                {
                    (dgvDoctorStats.DataSource as DataTable).DefaultView.RowFilter =
                        $"Specialty = '{specialty.Replace("'", "''")}'";
                }
                else
                {
                    (dgvDoctorStats.DataSource as DataTable).DefaultView.RowFilter = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new adminDashboard().Show();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {

        }
    }
}