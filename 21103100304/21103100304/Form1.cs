using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using NewtonsoftFormatting = Newtonsoft.Json.Formatting;
using XmlFormatting = System.Xml.Formatting;
namespace _21103100304
{
    public partial class Form1 : Form
    {
        private List<NhanVien> danhSachNhanVien;
        private int viTriHienTai = -1;
        private const string filePath = "nhanvien.json";

        public Form1()
        {
            InitializeComponent();
            danhSachNhanVien = DocDanhSachNhanVien(filePath);
            CapNhatDataGridView();
            HienThiThongTinNhanVien();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void CapNhatDataGridView()
        {
            // Xóa tất cả các cột cũ trước khi cập nhật
            dataGridView1.Columns.Clear();

            // Đặt AutoGenerateColumns thành true để tự động tạo cột từ danh sách
            dataGridView1.AutoGenerateColumns = true;

            // Cập nhật nguồn dữ liệu
            dataGridView1.DataSource = danhSachNhanVien;

            // Kiểm tra xem các cột đã được tạo ra hay chưa
            if (dataGridView1.Columns.Count > 0)
            {
                // Tùy chỉnh tiêu đề cột nếu cần
                dataGridView1.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dataGridView1.Columns["HoTen"].HeaderText = "Họ và Tên";
                dataGridView1.Columns["NamSinh"].HeaderText = "Năm Sinh";
                dataGridView1.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dataGridView1.Columns["BoPhan"].HeaderText = "Bộ Phận";
                dataGridView1.Columns["ChucVu"].HeaderText = "Chức Vụ";
                dataGridView1.Columns["HopDong"].HeaderText = "Hợp Đồng";
                dataGridView1.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            }
        }

        private List<NhanVien> DocDanhSachNhanVien(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<NhanVien>>(json) ?? new List<NhanVien>();
            }
            return new List<NhanVien>();
        }

        private void LuuDanhSachNhanVien()
        {
            string json = JsonConvert.SerializeObject(danhSachNhanVien, NewtonsoftFormatting.Indented);
           
            File.WriteAllText(filePath, json);
        }

        private void HienThiThongTinNhanVien()
        {
            if (danhSachNhanVien.Count == 0 || viTriHienTai < 0) return; // Kiểm tra chỉ số hợp lệ

            var nv = danhSachNhanVien[viTriHienTai];
            richTextBox1.Text = $"Mã nhân viên: {nv.MaNV}\nHọ và tên: {nv.HoTen}\n" +
                                $"Năm sinh: {nv.NamSinh:dd/MM/yyyy}\nGiới tính: {nv.GioiTinh}\n" +
                                $"Bộ phận: {nv.BoPhan}\nChức vụ: {nv.ChucVu}\n" +
                                $"Hợp đồng: {nv.HopDong}\nĐịa chỉ: {nv.DiaChi}";

            // Kiểm tra và hiển thị ảnh nếu tồn tại
            if (!string.IsNullOrEmpty(nv.Anh) && File.Exists(nv.Anh))
            {
                pictureBox1.Image = Image.FromFile(nv.Anh);
            }
            else
            {
                pictureBox1.Image = null; // Xóa ảnh nếu không tồn tại
            }
        }

        private void btnLui_Click(object sender, System.EventArgs e)
        {
            if (viTriHienTai > 0)
            {
                viTriHienTai--;
                HienThiThongTinNhanVien();
            }
        }

        private void btnTien_Click(object sender, System.EventArgs e)
        {
            if (viTriHienTai < danhSachNhanVien.Count - 1)
            {
                viTriHienTai++;
                HienThiThongTinNhanVien();
            }
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Form2 form2 = new Form2(danhSachNhanVien);
            if (form2.ShowDialog() == DialogResult.OK) // Nếu form2 được đóng với DialogResult OK
            {
                CapNhatDataGridView(); // Cập nhật lại DataGridView sau khi thêm mới
                LuuDanhSachNhanVien(); // Lưu danh sách nhân viên vào file
                                       // Thiết lập lại vị trí để hiển thị nhân viên mới
                viTriHienTai = danhSachNhanVien.Count - 1;
                HienThiThongTinNhanVien();
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (viTriHienTai >= 0 && viTriHienTai < danhSachNhanVien.Count)
            {
                danhSachNhanVien.RemoveAt(viTriHienTai);

                // Điều chỉnh vị trí hiện tại sau khi xóa
                if (viTriHienTai >= danhSachNhanVien.Count)
                    viTriHienTai = danhSachNhanVien.Count - 1;

                HienThiThongTinNhanVien();
                CapNhatDataGridView();
                LuuDanhSachNhanVien();

                // Đặt dòng chọn trong DataGridView
                if (viTriHienTai >= 0 && danhSachNhanVien.Count > 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[viTriHienTai].Cells[0];
                }
            }

        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {

            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < danhSachNhanVien.Count)
            {
                viTriHienTai = e.RowIndex; // Cập nhật vị trí hiện tại
                HienThiThongTinNhanVien(); // Hiển thị thông tin trong richTextBox
            }
        }
    }
}
