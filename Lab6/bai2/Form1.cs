using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void quảnLíVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Show();
        }

        private void quảnLíHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.MdiParent = this;
            form.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
