namespace medilabcsharp
{
    partial class patientDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            rdvPanel = new Panel();
            gifBackground = new PictureBox();
            viewRecordButton = new Button();
            rdvTitleLabel = new Label();
            newRdvButton = new Button();
            upcomingRdvGrid = new DataGridView();
            rdvPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upcomingRdvGrid).BeginInit();
            SuspendLayout();
            // 

            // 
            gifBackground.BackColor = Color.Transparent;
            gifBackground.Dock = DockStyle.Fill;
            gifBackground.Image = Image.FromFile("C:\\Users\\kouni_tg\\Downloads\\patient.gif");
            gifBackground.Location = new Point(0, 0);
            gifBackground.Name = "gifBackground";
            gifBackground.Size = new Size(800, 450);
            gifBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            gifBackground.TabIndex = 0;
            gifBackground.TabStop = false;

            // rdvPanel
            // 
            rdvPanel.BackColor = Color.White;
            rdvPanel.Controls.Add(viewRecordButton);
            rdvPanel.Controls.Add(rdvTitleLabel);
            rdvPanel.Controls.Add(newRdvButton);
            rdvPanel.Controls.Add(upcomingRdvGrid);
            rdvPanel.Location = new Point(-4, 1);
            rdvPanel.Name = "rdvPanel";
            rdvPanel.Size = new Size(1004, 599);
            rdvPanel.TabIndex = 0;
            // 
            // viewRecordButton
            // 
            viewRecordButton.Location = new Point(16, 341);
            viewRecordButton.Name = "viewRecordButton";
            viewRecordButton.Size = new Size(739, 95);
            viewRecordButton.TabIndex = 3;
            viewRecordButton.Text = "viewRecordButton";
            viewRecordButton.UseVisualStyleBackColor = true;
            viewRecordButton.Click += viewRecordButton_Click;
            // 
            // rdvTitleLabel
            // 
            rdvTitleLabel.AutoSize = true;
            rdvTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            rdvTitleLabel.Location = new Point(16, 17);
            rdvTitleLabel.Name = "rdvTitleLabel";
            rdvTitleLabel.Size = new Size(161, 30);
            rdvTitleLabel.TabIndex = 0;
            rdvTitleLabel.Text = "Appointments";
            rdvTitleLabel.Click += rdvTitleLabel_Click;
            // 
            // newRdvButton
            // 
            newRdvButton.Location = new Point(573, 17);
            newRdvButton.Name = "newRdvButton";
            newRdvButton.Size = new Size(182, 44);
            newRdvButton.TabIndex = 1;
            newRdvButton.Text = "Prendre un rendez-vous";
            // 
            // upcomingRdvGrid
            // 
            upcomingRdvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            upcomingRdvGrid.Location = new Point(16, 67);
            upcomingRdvGrid.Name = "upcomingRdvGrid";
            upcomingRdvGrid.ReadOnly = true;
            upcomingRdvGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            upcomingRdvGrid.Size = new Size(739, 251);
            upcomingRdvGrid.TabIndex = 2;
            // 
            // patientDashboard
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(rdvPanel);
            Controls.Add(gifBackground);
            Name = "patientDashboard";
            Text = "Tableau de Bord Patient";
            Load += patientDashboard_Load_1;
            rdvPanel.ResumeLayout(false);
            rdvPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)upcomingRdvGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)gifBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // UI CONTROL DECLARATIONS ONLY
        private Panel rdvPanel;
        private Label rdvTitleLabel;
        private Button newRdvButton;
        private DataGridView upcomingRdvGrid;
        private Button viewRecordButton;
        private PictureBox gifBackground;
    }
}