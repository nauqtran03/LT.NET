using System;
using System.Data;
using System.Data.SqlClient;
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
            LoadMaLop();
        }

        // Hàm tải dữ liệu sinh viên vào DataGridView
        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaSV, Ten, GioiTinh, NgaySinh, SDT, DiaChi, MaLop FROM tbSinhVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbSinhVien", conn);
                int siSo = (int)cmd.ExecuteScalar();
                lblSiSo.Text = "Sĩ số: " + siSo.ToString();
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

        // Hàm tải danh sách lớp vào ComboBox
        private void LoadMaLop()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaLop, TenLop FROM tbLop", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                cbMaLop.DataSource = dt;
                cbMaLop.DisplayMember = "TenLop"; // Hiển thị tên lớp
                cbMaLop.ValueMember = "MaLop"; // Lưu giá trị MaLop

                cbMaLop.SelectedIndex = -1; // Đặt về mặc định chưa chọn
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

        // Kiểm tra số điện thoại đã tồn tại trong cơ sở dữ liệu
        private bool IsPhoneNumberExist(string phoneNumber)
        {
            string query = "SELECT COUNT(*) FROM tbSinhVien WHERE SDT = @SDT";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SDT", phoneNumber);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0; // Nếu có ít nhất 1 sinh viên với số điện thoại này, trả về true
            }
        }

        // Kiểm tra số điện thoại đã tồn tại trong cơ sở dữ liệu, ngoại trừ số điện thoại của sinh viên đang sửa
        private bool IsPhoneNumberExist(string phoneNumber, string maSV)
        {
            string query = "SELECT COUNT(*) FROM tbSinhVien WHERE SDT = @SDT AND MaSV != @MaSV";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SDT", phoneNumber);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0; // Nếu có ít nhất 1 sinh viên khác có số điện thoại này, trả về true
            }
        }

        // Thêm sinh viên mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtTenSV.Text) ||
                cbMaLop.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSDT.Text)) // Kiểm tra số điện thoại
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sinh viên và chọn lớp.");
                return;
            }

            // Kiểm tra trùng số điện thoại
            if (IsPhoneNumberExist(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng nhập số điện thoại khác.");
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO tbSinhVien (MaSV, Ten, GioiTinh, NgaySinh, SDT, DiaChi, MaLop) VALUES (@MaSV, @Ten, @GioiTinh, @NgaySinh, @SDT, @DiaChi, @MaLop)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenSV.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaLop", cbMaLop.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Sửa thông tin sinh viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để sửa.");
                return;
            }

            // Kiểm tra trùng số điện thoại, trừ khi đây là số điện thoại của sinh viên đang sửa
            if (IsPhoneNumberExist(txtSDT.Text, txtMaSV.Text))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng nhập số điện thoại khác.");
                return;
            }

            try
            {
                conn.Open();
                string query = "UPDATE tbSinhVien SET Ten = @Ten, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi, MaLop = @MaLop WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenSV.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaLop", cbMaLop.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
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

        // Xóa sinh viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
                return;
            }

            try
            {
                conn.Open();
                string query = "DELETE FROM tbSinhVien WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Xử lý sự kiện khi người dùng click vào một sinh viên trong DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtTenSV.Text = row.Cells["Ten"].Value?.ToString();
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                dtpNgaySinh.Value = row.Cells["NgaySinh"].Value != null ? Convert.ToDateTime(row.Cells["NgaySinh"].Value) : DateTime.Now;
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                cbMaLop.SelectedValue = row.Cells["MaLop"].Value;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();

            // Hiển thị form tìm kiếm
            f3.Show();
        }
    }
}
