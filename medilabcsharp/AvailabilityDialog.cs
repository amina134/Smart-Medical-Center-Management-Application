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
    public partial class AvailabilityDialog : Form
    {
        public AvailabilityDialog()
        {
            InitializeComponent();
            LoadDays();
            SetDefaultTimes();
        }

        private void LoadDays()
        {
            cmbDay.Items.Clear();
            cmbDay.Items.AddRange(new string[]
            {
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            });
            cmbDay.SelectedIndex = 0;
        }

        private void SetDefaultTimes()
        {
            dtpStartTime.Value = DateTime.Today.AddHours(9); // Default start time: 9:00 AM
            dtpEndTime.Value = DateTime.Today.AddHours(17); // Default end time: 5:00 PM
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.ShowUpDown = true;
            dtpEndTime.ShowUpDown = true;
        }

        public DayOfWeek SelectedDay => (DayOfWeek)cmbDay.SelectedIndex;
        public TimeSpan StartTime => dtpStartTime.Value.TimeOfDay;
        public TimeSpan EndTime => dtpEndTime.Value.TimeOfDay;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateTimeRange())
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateTimeRange()
        {
            if (EndTime <= StartTime)
            {
                MessageBox.Show("End time must be after start time.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Optional: Validate against minimum time slot (e.g., at least 15 minutes)
            if ((EndTime - StartTime).TotalMinutes < 15)
            {
                MessageBox.Show("Time slot must be at least 15 minutes.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}