namespace medilabcsharp
{
    partial class NewAppointmentForm
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
            specialiteCombo = new ComboBox();
            medecinCombo = new ComboBox();
            rdvCalendar = new MonthCalendar();
            creneauxList = new ListBox();
            confirmButton = new Button();
            SuspendLayout();
            // 
            // specialiteCombo
            // 
            specialiteCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            specialiteCombo.Location = new Point(50, 50);
            specialiteCombo.Name = "specialiteCombo";
            specialiteCombo.Size = new Size(250, 23);
            specialiteCombo.TabIndex = 0;
            // 
            // medecinCombo
            // 
            medecinCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            medecinCombo.Enabled = false;
            medecinCombo.Location = new Point(350, 50);
            medecinCombo.Name = "medecinCombo";
            medecinCombo.Size = new Size(200, 23);
            medecinCombo.TabIndex = 1;
            // 
            // rdvCalendar
            // 
            rdvCalendar.Location = new Point(50, 100);
            rdvCalendar.MaxSelectionCount = 1;
            rdvCalendar.Name = "rdvCalendar";
            rdvCalendar.TabIndex = 2;
            // 
            // creneauxList
            // 
            creneauxList.FormattingEnabled = true;
            creneauxList.ItemHeight = 15;
            creneauxList.Location = new Point(350, 100);
            creneauxList.Name = "creneauxList";
            creneauxList.Size = new Size(200, 199);
            creneauxList.TabIndex = 3;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(200, 350);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(200, 40);
            confirmButton.TabIndex = 4;
            confirmButton.Text = "Confirmer le rendez-vous";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // NewAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 500);
            Controls.Add(confirmButton);
            Controls.Add(creneauxList);
            Controls.Add(rdvCalendar);
            Controls.Add(medecinCombo);
            Controls.Add(specialiteCombo);
            Name = "NewAppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nouveau Rendez-vous";
            Load += NewAppointmentForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ComboBox specialiteCombo;
        private System.Windows.Forms.ComboBox medecinCombo;
        private System.Windows.Forms.MonthCalendar rdvCalendar;
        private System.Windows.Forms.ListBox creneauxList;
        private System.Windows.Forms.Button confirmButton;

    }
}