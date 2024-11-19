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

namespace Bai1
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\quant\source\repos\Lab10\Bai1\bin\Debug\QuanLySinhVien.mdf;Integrated Security=True;Connect Timeout=30");

        public Form3()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaSV, Ten, DiaChi, GioiTinh FROM tbSinhVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa từ TextBox
                string queQuan = textBox1.Text.Trim();

                // Chuỗi truy vấn có điều kiện tìm kiếm
                string query = "SELECT MaSV, Ten, DiaChi, GioiTinh FROM tbSinhVien WHERE DiaChi LIKE @DiaChi";

                // Chuẩn bị câu lệnh SQL
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DiaChi", "%" + queQuan + "%");

                // Mở kết nối
                conn.Open();

                // Thực thi truy vấn
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData(); 
        }
    }
}
