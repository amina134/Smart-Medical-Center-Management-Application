using System.Resources;

namespace medilabcsharp
{
    partial class doctorDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doctorDashboard));
            dataGridViewAppointments = new DataGridView();
            btnViewMedicalRecord = new Button();
            gifBackground = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gifBackground).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(173, 93);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.Size = new Size(593, 278);
            dataGridViewAppointments.TabIndex = 0;
            dataGridViewAppointments.CellContentClick += dataGridViewAppointments_CellContentClick;
            // 
            // btnViewMedicalRecord
            // 
            btnViewMedicalRecord.Location = new Point(173, 398);
            btnViewMedicalRecord.Name = "btnViewMedicalRecord";
            btnViewMedicalRecord.Size = new Size(593, 60);
            btnViewMedicalRecord.TabIndex = 1;
            btnViewMedicalRecord.Text = "View Medical Record";
            btnViewMedicalRecord.UseVisualStyleBackColor = true;
            btnViewMedicalRecord.Click += btnViewMedicalRecord_Click;
            btnViewMedicalRecord.BackColor = Color.Beige;
            btnViewMedicalRecord.Font = new Font("Arial", 16, FontStyle.Bold); // Increase the font size (e.g., 16pt, bold)

            // 
            // gifBackground
            // 
            gifBackground.BackColor = Color.Transparent;
            gifBackground.Dock = DockStyle.Fill;
            gifBackground.Image = (Image)resources.GetObject("gifBackground.Image");
            gifBackground.Location = new Point(0, 0);
            gifBackground.Name = "gifBackground";
            gifBackground.Size = new Size(920, 523);
            gifBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            gifBackground.TabIndex = 0;
            gifBackground.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.DarkBlue;
            label1.ForeColor = Color.White;
            label1.Location = new Point(173, 31);
            label1.Name = "label1";
            label1.Size = new Size(250, 50);
            label1.TabIndex = 2;
            label1.Font = new Font("Arial", 16, FontStyle.Bold); // Increase the font size (e.g., 16pt, bold)

            label1.Text = "consult the timetable";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // doctorDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 523);
            Controls.Add(label1);
            Controls.Add(btnViewMedicalRecord);
            Controls.Add(dataGridViewAppointments);
            Controls.Add(gifBackground);
            Name = "doctorDashboard";
            Text = "doctorDashboard";
            Load += doctorDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox gifBackground;

        private DataGridView dataGridViewAppointments;
        private Button btnViewMedicalRecord;
        private Label label1;
    }
}