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
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\QuanLyBanHang_2024_v3.mdf;Integrated Security=True;Connect Timeout=30");

        public Form4()
        {
            InitializeComponent();
            LoadMaKhach();
            LoadMaHang();
        }
        private void LoadMaKhach()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaKH FROM KhachHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                cbMaKhach.DataSource = dt;
                cbMaKhach.DisplayMember = "MaKH"; // Hiển thị tên lớp
                cbMaKhach.ValueMember = "MaKH"; // Lưu giá trị MaLop

                cbMaKhach.SelectedIndex = -1; // Đặt về mặc định chưa chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadMaHang()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaMH FROM MatHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                cbMatHang.DataSource = dt;
                cbMatHang.DisplayMember = "MaMH"; // Hiển thị tên lớp
                cbMatHang.ValueMember = "MaMH"; // Lưu giá trị MaLop

                cbMatHang.SelectedIndex = -1; // Đặt về mặc định chưa chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txt_SoHieu_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            try
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Câu truy vấn SQL
                string query = @"SELECT HopDong.SoHieuHD, HopDong.MaKH, HopDong.NgayLap, 
                                HopDong_MatHang.MaMH, HopDong_MatHang.SoLuong
                         FROM HopDong
                         INNER JOIN HopDong_MatHang ON HopDong.SoHieuHD = HopDong_MatHang.SoHieuHD";

                // Dùng SqlDataAdapter để lấy dữ liệu
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btn_GoiDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
