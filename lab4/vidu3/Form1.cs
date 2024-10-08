using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vidu3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbTong.ReadOnly = true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbNhap.Text))
            {
                lsHienthi.Items.Add(tbNhap.Text);
                tbTong.Text = lsHienthi.Items.Count.ToString();
                tbNhap.Clear();
                tbTong.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!");
            }
        }

        private void btnXoadc_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tbTong.Text);
            if (lsHienthi.SelectedItems.Count !=0 )
            {
                lsHienthi.Items.Remove(lsHienthi.SelectedItems[0]);
            }
            tbTong.Text = (a-1).ToString();
        }

        private void btnXoadau_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tbTong.Text);
            lsHienthi.Items.RemoveAt(0);
            tbTong.Text = (a - 1).ToString();
        }

        private void btnXoacuoi_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(tbTong.Text);
            lsHienthi.Items.RemoveAt(lsHienthi.Items.Count - 1);
            tbTong.Text = (a - 1).ToString();
        }

        private void btnXoatatca_Click(object sender, EventArgs e)
        {
            lsHienthi.Items.Clear();
            tbTong.Text = "0";
        }
    }
}
