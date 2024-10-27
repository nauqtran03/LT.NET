using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21103100304
{
    public partial class Form2 : Form
    {
        private List<NhanVien> danhSachNhanVien;

        public Form2(List<NhanVien> danhSach)
        {
            InitializeComponent();
            danhSachNhanVien = danhSach;
            // Thêm các lựa chọn vào ComboBox GioiTinh
            cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });

            // Thêm các lựa chọn vào ComboBox DanToc
            cbDanToc.Items.AddRange(new string[] { "Kinh", "Nùng", "Tày", "Dao" });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName; // Đường dẫn đầy đủ của ảnh
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                MaNV = txtMaNV.Text,
                HoTen = txtLeHoaiKhiem.Text,
                NamSinh = dateNamSinh.Value,
                GioiTinh = cbGioiTinh.Text,
                BoPhan = txtBoPhan.Text,
                ChucVu = txtChucVu.Text,
                HopDong = txtHopDong.Text,
                DiaChi = txtDiaChi.Text,
                Anh = pictureBox1.ImageLocation
            };

            danhSachNhanVien.Add(nv);

            this.DialogResult = DialogResult.OK; 
            this.Close(); // Đóng Form2
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
           
            btnLuu_Click(sender, e);

            txtMaNV.Clear();
            txtLeHoaiKhiem.Clear();
            txtBoPhan.Clear();
            txtChucVu.Clear();
            txtHopDong.Clear();
            txtDiaChi.Clear();
            pictureBox1.ImageLocation = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtLeHoaiKhiem.Clear();
            txtBoPhan.Clear();
            txtChucVu.Clear();
            txtHopDong.Clear();
            txtDiaChi.Clear();
            pictureBox1.ImageLocation = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoPhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHopDong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateNRa_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateNVao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateNamSinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLeHoaiKhiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
