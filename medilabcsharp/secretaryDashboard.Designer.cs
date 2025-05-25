using System.Resources;

namespace medilabcsharp
{
    partial class secretaryDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(secretaryDashboard));
            dgvPatients = new DataGridView();
            dgvAppointments = new DataGridView();
            btnScheduleAppointment = new Button();
            gifBackground = new PictureBox();
            btnCancelAppointment = new Button();
            btnUpdateAppointment = new Button();
            label1 = new Label();
            btnGenerateInvoice = new Button();
            patientstitle = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gifBackground).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(48, 108);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(254, 154);
            dgvPatients.TabIndex = 0;
            // 
            // dgvAppointments
            // 
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Location = new Point(48, 326);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.Size = new Size(670, 153);
            dgvAppointments.TabIndex = 1;
            // 
            // btnScheduleAppointment
            // 
            btnScheduleAppointment.Location = new Point(744, 326);
            btnScheduleAppointment.Name = "btnScheduleAppointment";
            btnScheduleAppointment.Size = new Size(160, 39);
            btnScheduleAppointment.TabIndex = 2;
            btnScheduleAppointment.Text = "Schedule";
            btnScheduleAppointment.UseVisualStyleBackColor = true;
            btnScheduleAppointment.Click += btnScheduleAppointment_Click;
            // 
            // gifBackground
            // 
            gifBackground.BackColor = Color.Transparent;
            gifBackground.Dock = DockStyle.Fill;
            gifBackground.Image = (Image)resources.GetObject("gifBackground.Image");
            gifBackground.Location = new Point(0, 0);
            gifBackground.Name = "gifBackground";
            gifBackground.Size = new Size(975, 572);
            gifBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            gifBackground.TabIndex = 0;
            gifBackground.TabStop = false;
            // 
            // btnCancelAppointment
            // 
            btnCancelAppointment.Location = new Point(744, 418);
            btnCancelAppointment.Name = "btnCancelAppointment";
            btnCancelAppointment.Size = new Size(160, 39);
            btnCancelAppointment.TabIndex = 3;
            btnCancelAppointment.Text = "Cancel";
            btnCancelAppointment.UseVisualStyleBackColor = true;
            btnCancelAppointment.Click += btnCancelAppointment_Click;
            // 
            // btnUpdateAppointment
            // 
            btnUpdateAppointment.Location = new Point(744, 371);
            btnUpdateAppointment.Name = "btnUpdateAppointment";
            btnUpdateAppointment.Size = new Size(160, 41);
            btnUpdateAppointment.TabIndex = 4;
            btnUpdateAppointment.Text = "Update";
            btnUpdateAppointment.UseVisualStyleBackColor = true;
            btnUpdateAppointment.Click += btnUpdateAppointment_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(506, -19);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 5;
            label1.Text = "Appointments Actions:";
            // 
            // btnGenerateInvoice
            // 
            btnGenerateInvoice.BackColor = Color.Beige;
            btnGenerateInvoice.Font = new Font("Arial", 16F, FontStyle.Bold);
            btnGenerateInvoice.Location = new Point(48, 485);
            btnGenerateInvoice.Name = "btnGenerateInvoice";
            btnGenerateInvoice.Size = new Size(670, 65);
            btnGenerateInvoice.TabIndex = 6;
            btnGenerateInvoice.Text = "Genrerate bill";
            btnGenerateInvoice.UseVisualStyleBackColor = false;
            btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            // 
            // patientstitle
            // 
            patientstitle.AutoSize = true;
            patientstitle.BackColor = Color.Beige;
            patientstitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            patientstitle.Location = new Point(48, 79);
            patientstitle.Name = "patientstitle";
            patientstitle.Size = new Size(95, 26);
            patientstitle.TabIndex = 7;
            patientstitle.Text = "Patients";
            // 
            // label2
            // 
            label2.BackColor = Color.Beige;
            label2.Font = new Font("Arial", 16F, FontStyle.Bold);
            label2.Location = new Point(48, 280);
            label2.Name = "label2";
            label2.Size = new Size(240, 36);
            label2.TabIndex = 8;
            label2.Text = "See All Appointments";
            // 
            // label3
            // 
            label3.BackColor = Color.Beige;
            label3.Font = new Font("Arial", 36F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(350, 24);
            label3.Name = "label3";
            label3.Size = new Size(625, 81);
            label3.TabIndex = 2;
            label3.Text = "     Secretary Dashboard\r\n\r\n";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // secretaryDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 572);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(patientstitle);
            Controls.Add(btnGenerateInvoice);
            Controls.Add(label1);
            Controls.Add(btnUpdateAppointment);
            Controls.Add(btnCancelAppointment);
            Controls.Add(btnScheduleAppointment);
            Controls.Add(dgvAppointments);
            Controls.Add(dgvPatients);
            Controls.Add(gifBackground);
            Name = "secretaryDashboard";
            Text = "secretaryDashboard";
            WindowState = FormWindowState.Maximized;
            Load += secretaryDashboard_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPatients;
        private DataGridView dgvAppointments;
        private Button btnScheduleAppointment;
        private Button btnCancelAppointment;
        private Button btnUpdateAppointment;
        private Label label1;
        private Button btnGenerateInvoice;
        private Label patientstitle;
        private Label label2;
        private Label label3;
        private PictureBox gifBackground;

    }
}