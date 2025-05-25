using MedicalCenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilabcsharp
{
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void doctor_Click(object sender, EventArgs e)
        {

        }

        private void Patient_Click(object sender, EventArgs e)
        {
            this.Hide();
            new adminDocter().Show();
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnManageAvailabilities_Click(object sender, EventArgs e)
        {
            new ManageDoctorAvailabilitiesForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {   this.Hide();
            new StatisticsForm().Show();
        }
    }
}
