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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\QuanLyBanHang_2024_v3.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
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

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Kiểm tra trùng mã khách hàng
                string checkMaKHQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand checkMaKHCmd = new SqlCommand(checkMaKHQuery, conn);
                checkMaKHCmd.Parameters.AddWithValue("@MaKH", txt_MaKhachHang.Text);

                int count = (int)checkMaKHCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!");
                }
                else
                {
                    string query = "INSERT INTO KhachHang (MaKH, TenKH, GioiTinh, DiaChi, DienThoai) VALUES (@MaKH, @TenKH, @GioiTinh, @DiaChi, @DienThoai)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaKH", txt_MaKhachHang.Text);
                    cmd.Parameters.AddWithValue("@TenKH", txt_HoTen.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", cbo_GioiTinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                    cmd.Parameters.AddWithValue("@DienThoai", txt_DienThoai.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm khách hàng thành công!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng để sửa.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_HoTen.Text) || string.IsNullOrWhiteSpace(txt_DiaChi.Text) || cbo_GioiTinh.SelectedItem == null || string.IsNullOrWhiteSpace(txt_DienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "UPDATE KhachHang SET TenKH = @TenKH, GioiTinh = @GioiTinh, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKH = @MaKH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", txt_MaKhachHang.Text);
                    cmd.Parameters.AddWithValue("@TenKH", txt_HoTen.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", cbo_GioiTinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                    cmd.Parameters.AddWithValue("@DienThoai", txt_DienThoai.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã khách hàng để sửa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txt_MaKhachHang.Text);

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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txt_MaKhachHang.Text = row.Cells["MaKH"].Value?.ToString();
                txt_HoTen.Text = row.Cells["TenKH"].Value?.ToString();
                cbo_GioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txt_DiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txt_DienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
            }
        }
    }
}
