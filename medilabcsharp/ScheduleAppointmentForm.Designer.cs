namespace medilabcsharp
{
    partial class ScheduleAppointmentForm
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
            SuspendLayout();
            // 
            // ScheduleAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "ScheduleAppointmentForm";
            Text = "ScheduleAppointmentForm";
            Load += ScheduleAppointmentForm_Load;
            ResumeLayout(false);


            this.lblPatient = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.lstTimeSlots = new System.Windows.Forms.ListBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();

            // lblPatient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(20, 20);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(46, 13);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient:";

            // cmbPatient
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(100, 17);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(200, 21);
            this.cmbPatient.TabIndex = 1;

            // lblDoctor
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(20, 50);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(42, 13);
            this.lblDoctor.TabIndex = 2;
            this.lblDoctor.Text = "Doctor:";

            // cmbDoctor
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(100, 47);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(200, 21);
            this.cmbDoctor.TabIndex = 3;
       //     this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.cmbDoctor_SelectedIndexChanged);

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";

            // dtpDate
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(100, 77);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(20, 110);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(70, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Available Slots:";

            // lstTimeSlots
            this.lstTimeSlots.FormattingEnabled = true;
            this.lstTimeSlots.Location = new System.Drawing.Point(100, 110);
            this.lstTimeSlots.Name = "lstTimeSlots";
            this.lstTimeSlots.Size = new System.Drawing.Size(100, 95);
            this.lstTimeSlots.TabIndex = 7;

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(20, 220);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Duration:";

            // numDuration
            this.numDuration.Location = new System.Drawing.Point(100, 218);
            this.numDuration.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(60, 20);
            this.numDuration.TabIndex = 9;
            this.numDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});

            // lblReason
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(20, 250);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(44, 13);
            this.lblReason.TabIndex = 10;
            this.lblReason.Text = "Reason:";

            // txtReason
            this.txtReason.Location = new System.Drawing.Point(100, 247);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(200, 60);
            this.txtReason.TabIndex = 11;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(150, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(230, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ScheduleAppointmentForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 370);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lstTimeSlots);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.cmbPatient);
            this.Controls.Add(this.lblPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleAppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule New Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ListBox lstTimeSlots;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}