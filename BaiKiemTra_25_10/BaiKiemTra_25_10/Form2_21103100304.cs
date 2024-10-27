using BaiKiemTra_25_10.DomainClass;
using BaiKiemTra_25_10.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaiKiemTra_25_10
{
    public partial class Form2 : Form
    {
        NhanVienRepositories _repos = new NhanVienRepositories();
        private readonly Form1 _form1;
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
            comboBoxGioiTinh.Items.Add("Nam");
            comboBoxGioiTinh.Items.Add("Nữ");
        }
        private void Clear()
        {
            txtMaNV.Text = "";
            txtTen.Text = "";
            txtBoPhan.Text = "";
            txtChucVu.Text = "";
            txtHopDong.Text = "";
            txtDiaChi.Text = "";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.EmployeeId = txtMaNV.Text;
            obj.FullName = txtTen.Text;
            obj.BirthYear = dateTimePicker1.Value;
            obj.Gender = comboBoxGioiTinh.SelectedItem?.ToString();
            obj.Department = txtBoPhan.Text;
            obj.Position = txtChucVu.Text;
            obj.Address = txtDiaChi.Text;


            _repos.AddEmployee(obj);
            _form1.LoadGidNV();
            Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.EmployeeId = txtMaNV.Text;
            obj.FullName = txtTen.Text;
            obj.BirthYear = dateTimePicker1.Value;
            obj.Gender = comboBoxGioiTinh.SelectedItem?.ToString();
            obj.Department = txtBoPhan.Text;
            obj.Position = txtChucVu.Text;
            obj.Address = txtDiaChi.Text;

            _repos.AddEmployee(obj);
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
