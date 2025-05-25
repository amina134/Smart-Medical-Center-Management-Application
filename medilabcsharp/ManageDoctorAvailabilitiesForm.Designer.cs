namespace MedicalCenter
{
    partial class ManageDoctorAvailabilitiesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            cmbDoctors = new ComboBox();
            dgvAvailabilities = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvAvailabilities).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 16);
            label1.TabIndex = 0;
            label1.Text = "Doctor:";
            // 
            // cmbDoctors
            // 
            cmbDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctors.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbDoctors.FormattingEnabled = true;
            cmbDoctors.Location = new Point(89, 14);
            cmbDoctors.Margin = new Padding(4, 3, 4, 3);
            cmbDoctors.Name = "cmbDoctors";
            cmbDoctors.Size = new Size(349, 24);
            cmbDoctors.TabIndex = 1;
            cmbDoctors.SelectedIndexChanged += cmbDoctors_SelectedIndexChanged;
            // 
            // dgvAvailabilities
            // 
            dgvAvailabilities.AllowUserToAddRows = false;
            dgvAvailabilities.AllowUserToDeleteRows = false;
            dgvAvailabilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailabilities.BackgroundColor = SystemColors.Window;
            dgvAvailabilities.BorderStyle = BorderStyle.Fixed3D;
            dgvAvailabilities.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAvailabilities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAvailabilities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAvailabilities.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAvailabilities.Location = new Point(14, 58);
            dgvAvailabilities.Margin = new Padding(4, 3, 4, 3);
            dgvAvailabilities.MultiSelect = false;
            dgvAvailabilities.Name = "dgvAvailabilities";
            dgvAvailabilities.ReadOnly = true;
            dgvAvailabilities.RowHeadersVisible = false;
            dgvAvailabilities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailabilities.Size = new Size(653, 346);
            dgvAvailabilities.TabIndex = 2;
            dgvAvailabilities.CellMouseDown += dgvAvailabilities_CellMouseDown;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(14, 415);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 35);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(139, 416);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(117, 35);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(551, 415);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 35);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(107, 22);
            editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // ManageDoctorAvailabilitiesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 463);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvAvailabilities);
            Controls.Add(cmbDoctors);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageDoctorAvailabilitiesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Doctor Availabilities";
            Load += ManageDoctorAvailabilitiesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAvailabilities).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDoctors;
        private System.Windows.Forms.DataGridView dgvAvailabilities;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}