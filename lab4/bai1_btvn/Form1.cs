using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai1_btvn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
         
                    string selectedItem = listBox1.SelectedItem.ToString();
                    txtKq.Text = "Bạn đã chọn " + selectedItem;
               
            }
            else 
            {
                MessageBox.Show("Vui long chọn một liên kết từ danh sách");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKq.Clear();
            listBox1.ClearSelected();
        }
    }
}
