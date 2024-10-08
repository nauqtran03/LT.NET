using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2_btvn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                string selected = comboBox1.SelectedItem.ToString();
                textBox1 .Text = "Bạn đã chọn website "+ selected;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn liên kết bạn muốn tới");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Items.Clear();
        }
    }
}
