namespace medilabcsharp
{
    partial class adminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminDashboard));
            gifBackground = new PictureBox();
            Patient = new Button();
            btnManageAvailabilities = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)gifBackground).BeginInit();
            SuspendLayout();
            // 
            // gifBackground
            // 
            gifBackground.BackColor = Color.Transparent;
            gifBackground.Dock = DockStyle.Fill;
            gifBackground.Image = (Image)resources.GetObject("gifBackground.Image");
            gifBackground.Location = new Point(0, 0);
            gifBackground.Name = "gifBackground";
            gifBackground.Size = new Size(1009, 526);
            gifBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            gifBackground.TabIndex = 0;
            gifBackground.TabStop = false;
            // 
            // Patient
            // 
            Patient.BackColor = Color.DarkBlue;
            Patient.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Patient.ForeColor = Color.White;
            Patient.Location = new Point(99, 66);
            Patient.Name = "Patient";
            Patient.Size = new Size(294, 86);
            Patient.TabIndex = 1;
            Patient.Text = "Manage Users";
            Patient.UseVisualStyleBackColor = false;
            Patient.Click += Patient_Click;
            // 
            // btnManageAvailabilities
            // 
            btnManageAvailabilities.BackColor = Color.DarkBlue;
            btnManageAvailabilities.FlatStyle = FlatStyle.Flat;
            btnManageAvailabilities.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnManageAvailabilities.ForeColor = Color.White;
            btnManageAvailabilities.Location = new Point(427, 66);
            btnManageAvailabilities.Name = "btnManageAvailabilities";
            btnManageAvailabilities.Size = new Size(294, 86);
            btnManageAvailabilities.TabIndex = 3;
            btnManageAvailabilities.Text = resources.GetString("btnManageAvailabilities.Text");
            btnManageAvailabilities.UseVisualStyleBackColor = false;
            btnManageAvailabilities.Click += btnManageAvailabilities_Click;
            // 
            // button1
            // 
            button1.Location = new Point(8, 8);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(786, 66);
            button2.Name = "button2";
            button2.Size = new Size(294, 86);
            button2.TabIndex = 4;
            button2.Text = "statistics";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // adminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 526);
            Controls.Add(button2);
            Controls.Add(btnManageAvailabilities);
            Controls.Add(Patient);
            Controls.Add(gifBackground);
            Name = "adminDashboard";
            Text = "adminDashboard";
            Load += adminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)gifBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Patient;
        private Button btnManageAvailabilities;
        private PictureBox gifBackground;
        private Button button1;
        private Button button2;
    }
}