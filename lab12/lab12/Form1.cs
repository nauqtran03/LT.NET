using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                double sothu1 = double.Parse(tb1.Text);
                double sothu2 = double.Parse(tb2.Text);

                double ketqua = sothu1 + sothu2;
                tbKq.Text = ketqua.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            tb1.Text = "";
            tb2.Text = "";
            tbKq.Text = "";
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
