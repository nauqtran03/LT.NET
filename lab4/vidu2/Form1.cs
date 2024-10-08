using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vidu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
         
            InitializeComponent();
            txtKq.ReadOnly = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((txtSo1.Text == "") || (txtSo2.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập vào một số", "Nhập số");
                txtSo1.Focus();
            }
            else
            {
                double so1, so2, cong, tru, nhan, chia;
                int pt;
                so1 = Convert.ToDouble(txtSo1.Text);
                so2 = Convert.ToDouble(txtSo2.Text);
                pt = cb1.SelectedIndex;
                switch (pt)
                {
                    case 0:
                        cong = so1 + so2;
                        txtKq.Text = cong.ToString();
                        break;
                    case 1:
                        tru = so1 - so2;
                        txtKq.Text = tru.ToString();
                        break;
                    case 2:
                        nhan = so1 * so2;
                        txtKq.Text = nhan.ToString();
                        break;
                    case 3:
                        if (so2 != 0)
                        {
                            chia = so1 / so2;
                            txtKq.Text = chia.ToString();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Không chia được do mẫu số = 0");
                        }
                        break;
                }
            }
        }

       
    }
}
