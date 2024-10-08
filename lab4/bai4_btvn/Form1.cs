using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai4_btvn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputData = textBox1.Text;
            listBox1.Items.Add(inputData);
            textBox1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string inputData = textBox1.Text;
                listBox1.Items.Add(inputData);
                textBox1.Clear();
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            for (int i =0; i < listBox1.Items.Count; i++)
            {
                int value = int.Parse(listBox1.Items[i].ToString());

                value += 2;

                listBox1.Items[i] = value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                int value = int.Parse(listBox1.Items[i].ToString());

                if (value % 2 == 0)
                {
                    MessageBox.Show("Số chẵn đầu tiên là: " + value);
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i = listBox1.Items.Count - 1; i >=0; i--)
            {
                int value = int.Parse(listBox1.Items[i].ToString());
                if(value %2 != 0)
                {
                    MessageBox.Show("Số lẻ cuối cùng là: "+value);
                    break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count -1 );
            }
        }
    }
}
