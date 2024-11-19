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

namespace Qlibanhang_thayTuan
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\QuanLyBanHang_2024_v3.mdf;Integrated Security=True;Connect Timeout=30");
        public Form3()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MatHang", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
 

        private void btn_GoiDuLieu_Click(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE MatHang SET TenMH = @TenMH, DonViTinh = @DonViTinh, DonGia = @DonGia WHERE MaMH = @MaMH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMH", txt_MaKhachHang.Text);
                    cmd.Parameters.AddWithValue("@TenMH", txt_HoTen.Text);
                    cmd.Parameters.AddWithValue("@DonViTinh", txt_DiaChi.Text);
                    cmd.Parameters.AddWithValue("@DonGia", txt_DienThoai.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                conn.Open();

                // Kiểm tra mã khách hàng có trùng không
                string checkMaKHQuery = "SELECT COUNT(*) FROM MatHang WHERE MaMH = @MaMH";
                SqlCommand checkMaKHCmd = new SqlCommand(checkMaKHQuery, conn);
                checkMaKHCmd.Parameters.AddWithValue("@MaMH", txt_MaKhachHang.Text);
                int maMHCount = (int)checkMaKHCmd.ExecuteScalar();

                if (maMHCount > 0)
                {
                    // Nếu mã khách hàng đã tồn tại, hiển thị thông báo lỗi
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.");
                }
                else
                {

                    // Nếu cả mã khách hàng và số điện thoại đều chưa tồn tại, tiến hành thêm mới
                    string query = "INSERT INTO MatHang (MaMH, TenMH, DonViTinh, DonGia) VALUES (@MaMH, @TenMH, @DonViTinh, @DonGia)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaMH", txt_MaKhachHang.Text);
                    cmd.Parameters.AddWithValue("@TenMH", txt_HoTen.Text);

                    cmd.Parameters.AddWithValue("@DonViTinh", txt_DiaChi.Text);
                    cmd.Parameters.AddWithValue("@DonGia", txt_DienThoai.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txt_MaKhachHang.Text = row.Cells["MaMH"].Value?.ToString();
                txt_HoTen.Text = row.Cells["TenMH"].Value?.ToString();
                txt_DiaChi.Text = row.Cells["DonViTinh"].Value?.ToString();
                txt_DienThoai.Text = row.Cells["DonGia"].Value?.ToString();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "DELETE FROM MatHang WHERE MaMH = @MaMH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMH", txt_MaKhachHang.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa khách hàng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
