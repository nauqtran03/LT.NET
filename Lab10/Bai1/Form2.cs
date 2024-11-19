using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bai1
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\quant\source\repos\Lab10\Bai1\bin\Debug\QuanLySinhVien.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassWord.Text = "";
            txtUserName.Clear();
            txtUserName.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassWord.UseSystemPasswordChar = false; // Hiển thị mật khẩu
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;  // Ẩn mật khẩu bằng ký tự *
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;

            if (ValidateLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                // Chuyển đến form chính
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai tên tài khoản hoặc mật khẩu!");
            }
        }
        private bool ValidateLogin(string username, string password)
        {
 
                conn.Open();
                string query = "SELECT * FROM Login WHERE username = @username AND password = @password AND sate = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
        }
    }
}
