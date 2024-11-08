using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\quanlibanhang.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public Form1()
        {
            InitializeComponent();
            LoadData(); // Tải dữ liệu khi khởi động form
        }

        // Hàm tải dữ liệu từ bảng khách hàng lên DataGridView
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

        // Hàm thêm khách hàng
        private void AddRecord()
        {
            try
            {
                conn.Open();

                // Kiểm tra mã khách hàng có trùng không
                string checkMaKHQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand checkMaKHCmd = new SqlCommand(checkMaKHQuery, conn);
                checkMaKHCmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                int maKHCount = (int)checkMaKHCmd.ExecuteScalar();

                if (maKHCount > 0)
                {
                    // Nếu mã khách hàng đã tồn tại, hiển thị thông báo lỗi
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.");
                }
                else
                {
                    // Kiểm tra số điện thoại có trùng không
                    string checkSDTQuery = "SELECT COUNT(*) FROM KhachHang WHERE DienThoai = @DienThoai";
                    SqlCommand checkSDTCmd = new SqlCommand(checkSDTQuery, conn);
                    checkSDTCmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                    int sdtCount = (int)checkSDTCmd.ExecuteScalar();

                    if (sdtCount > 0)
                    {
                        // Nếu số điện thoại đã tồn tại, hiển thị thông báo lỗi
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số khác.");
                    }
                    else
                    {
                        // Nếu cả mã khách hàng và số điện thoại đều chưa tồn tại, tiến hành thêm mới
                        string query = "INSERT INTO KhachHang (MaKH, HoTen, GioiTinh, DiaChi, DienThoai) VALUES (@MaKH, @HoTen, @GioiTinh, @DiaChi, @DienThoai)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công!");
                        LoadData();
                    }
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

        // Hàm sửa thông tin khách hàng
        private void UpdateRecord()
        {
            try
            {
                conn.Open();
                string query = "UPDATE KhachHang SET HoTen = @HoTen, GioiTinh = @GioiTinh, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!");
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

        // Hàm xóa khách hàng
        private void DeleteRecord()
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
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

        // Hàm tìm kiếm khách hàng theo mã khách hàng
        private void SearchRecord()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
            AddRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchRecord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
