using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolFbNew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacebookControl controlFB = new FacebookControl();
            controlFB.OpenonlyFB(txtUserNameFB.Text,txtPasswordFB.Text,txtBrowserFB.Text);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FacebookControl controlFB = new FacebookControl();
            controlFB.testing();
        }
    }
}
