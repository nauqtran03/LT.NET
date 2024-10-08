using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vidu1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbChmau.Text == "Yellow")
            {
                this.BackColor = Color.Yellow;
            }
            if (cbChmau.Text == "Red")
            {
                this.BackColor = Color.Red;
            }
            if (cbChmau.Text == "Blue")
            {
                this.BackColor = Color.Blue;
            }
            if (cbChmau.Text == "Green")
            {
                this.BackColor = Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Ban co muon dong chuong trinh?", "Thong Bao", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
