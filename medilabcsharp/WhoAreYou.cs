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
    public partial class WhoAreYou : Form
    {
        public WhoAreYou()
        {
            InitializeComponent();
        }

        private void admin_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
