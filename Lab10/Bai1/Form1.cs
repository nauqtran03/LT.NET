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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\quant\source\repos\Lab10\Bai1\bin\Debug\QuanLySinhVien.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        // Hàm tải dữ liệu từ bảng tbSinhVien lên DataGridView và đếm sĩ số
        private void LoadData()
        {
            conn.Open();
            try
            {
                // Lấy dữ liệu sinh viên và hiển thị lên DataGridView
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSinhVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                // Đếm số sinh viên và hiển thị sĩ số
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbSinhVien", conn);
                int siSo = (int)cmd.ExecuteScalar();
                lblSiSo.Text = "Sĩ số: " + siSo.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        // Hàm Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string query = "INSERT INTO tbSinhVien (MaSV, Ten, GioiTinh, NgaySinh, SDT, DiaChi, MaCS, MaLop) " +
                               "VALUES (@MaSV, @Ten, @GioiTinh, @NgaySinh, @SDT, @DiaChi, @MaCS, @MaLop)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenSV.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaCS", txtMaCS.Text);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
            }
            LoadData();
        }

        // Hàm Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string query = "UPDATE tbSinhVien SET Ten = @Ten, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, " +
                               "SDT = @SDT, DiaChi = @DiaChi, MaCS = @MaCS, MaLop = @MaLop WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenSV.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaCS", txtMaCS.Text);
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
            }
            LoadData();
        }

        // Hàm Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string query = "DELETE FROM tbSinhVien WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
            }
            LoadData();
        }

        // Hàm Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hiển thị thông tin sinh viên khi nhấp vào hàng trong DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtTenSV.Text = row.Cells["Ten"].Value.ToString();
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtMaCS.Text = row.Cells["MaCS"].Value.ToString();
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
            }
        }

    }
}
