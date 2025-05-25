namespace medilabcsharp
{
    partial class adminDocter
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
            firstName = new TextBox();
            lastName = new TextBox();
            email = new TextBox();
            phoneNum = new TextBox();
            gender = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            dataGridView1 = new DataGridView();
            add = new Button();
            update = new Button();
            delete = new Button();
            home = new Button();
            role = new ComboBox();
            password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // firstName
            // 
            firstName.Location = new Point(81, 62);
            firstName.Name = "firstName";
            firstName.Size = new Size(119, 23);
            firstName.TabIndex = 0;
            // 
            // lastName
            // 
            lastName.Location = new Point(81, 120);
            lastName.Name = "lastName";
            lastName.Size = new Size(119, 23);
            lastName.TabIndex = 1;
            // 
            // email
            // 
            email.Location = new Point(233, 62);
            email.Name = "email";
            email.Size = new Size(119, 23);
            email.TabIndex = 2;
            // 
            // phoneNum
            // 
            phoneNum.Location = new Point(396, 120);
            phoneNum.Name = "phoneNum";
            phoneNum.Size = new Size(100, 23);
            phoneNum.TabIndex = 3;
            // 
            // gender
            // 
            gender.FormattingEnabled = true;
            gender.IntegralHeight = false;
            gender.Items.AddRange(new object[] { "female", "male" });
            gender.Location = new Point(532, 62);
            gender.Name = "gender";
            gender.Size = new Size(126, 23);
            gender.TabIndex = 4;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(532, 120);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(126, 23);
            dtpBirthDate.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(81, 171);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(839, 303);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // add
            // 
            add.BackColor = Color.SkyBlue;
            add.Location = new Point(965, 134);
            add.Name = "add";
            add.Size = new Size(100, 40);
            add.TabIndex = 7;
            add.Text = "Add";
            add.UseVisualStyleBackColor = false;
            add.Click += add_Click;
            // 
            // update
            // 
            update.BackColor = Color.LightGreen;
            update.Location = new Point(965, 194);
            update.Name = "update";
            update.Size = new Size(100, 40);
            update.TabIndex = 8;
            update.Text = "Update";
            update.UseVisualStyleBackColor = false;
            update.Click += update_Click;
            // 
            // delete
            // 
            delete.BackColor = Color.LightCoral;
            delete.Location = new Point(965, 255);
            delete.Name = "delete";
            delete.Size = new Size(100, 40);
            delete.TabIndex = 9;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // home
            // 
            home.BackColor = Color.LightYellow;
            home.Location = new Point(965, 315);
            home.Name = "home";
            home.Size = new Size(100, 40);
            home.TabIndex = 10;
            home.Text = "Home";
            home.UseVisualStyleBackColor = false;
            home.Click += home_Click;
            // 
            // role
            // 
            role.FormattingEnabled = true;
            role.Items.AddRange(new object[] { "Doctor", "Patient", "Secretary" });
            role.Location = new Point(233, 120);
            role.Name = "role";
            role.Size = new Size(126, 23);
            role.TabIndex = 13;
            // 
            // password
            // 
            password.Location = new Point(396, 60);
            password.Name = "password";
            password.Size = new Size(115, 23);
            password.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 44);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 15;
            label1.Text = "firstname";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 102);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 16;
            label2.Text = "lastName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(233, 46);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 17;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(396, 100);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 18;
            label4.Text = "Phone Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 102);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 19;
            label5.Text = "Role";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(532, 44);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 20;
            label6.Text = "Gender";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(532, 102);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 21;
            label7.Text = "Date of Birth";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(396, 42);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 22;
            label8.Text = "Password";
            // 
            // adminDocter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 523);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(password);
            Controls.Add(role);
            Controls.Add(home);
            Controls.Add(delete);
            Controls.Add(update);
            Controls.Add(add);
            Controls.Add(dataGridView1);
            Controls.Add(dtpBirthDate);
            Controls.Add(gender);
            Controls.Add(phoneNum);
            Controls.Add(email);
            Controls.Add(lastName);
            Controls.Add(firstName);
            Name = "adminDocter";
            ShowIcon = false;
            Text = "adminPatientConfiguration";
            Load += adminPatient_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstName;
        private TextBox lastName;
        private TextBox email;
        private TextBox phoneNum;
        private ComboBox gender;
        private DateTimePicker dtpBirthDate;
        private DataGridView dataGridView1;
        private Button add;
        private Button update;
        private Button delete;
        private Button home;
        private ComboBox role;
        private TextBox password;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
