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
    public partial class Form1 : Form
    {
        int currentRowIndex = 0;
        NhanVienRepositories _repos = new NhanVienRepositories();
        public Form1()
        {
            InitializeComponent();
            LoadGidNV();
            datagrid.SelectionChanged += datagrid_SelectionChanged;
            datagrid.CellClick += datagrid_CellClick;
        }
        public void LoadGidNV()
        {
            int stt = 1;
            Type type = typeof(Employees);
            int slThuocTinh = type.GetProperties().Length;
            datagrid.ColumnCount = slThuocTinh;

            datagrid.Columns[0].Name = "Mã NV";
            datagrid.Columns[1].Name = "Họ tên";
            datagrid.Columns[2].Name = "Năm sinh";
            datagrid.Columns[3].Name = "Giới tính";
            datagrid.Columns[4].Name = "Bộ phận";
            datagrid.Columns[5].Name = "Chức vụ";
            datagrid.Columns[6].Name = "Hợp đồng";
            datagrid.Columns[7].Name = "Địa chỉ";
            datagrid.Columns[8].Name = "URL img";
            datagrid.Rows.Clear();

            foreach (var stu in _repos.GetEmployees())
            {
                datagrid.Rows.Add(stu.EmployeeId, stu.FullName, stu.BirthYear, stu.Gender, stu.Department, stu.Position, stu.ContractType, stu.Address, stu.ImgUrl);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = datagrid.Rows[e.RowIndex];  

                rtb.Text = $"Mã NV: {selectedRow.Cells["Mã NV"].Value}\n" +
                           $"Họ tên: {selectedRow.Cells["Họ tên"].Value}\n" +
                           $"Năm sinh: {selectedRow.Cells["Năm sinh"].Value}\n" +
                           $"Giới tính: {selectedRow.Cells["Giới tính"].Value}\n" +
                           $"Bộ phận: {selectedRow.Cells["Bộ phận"].Value}\n" +
                           $"Chức vụ: {selectedRow.Cells["Chức vụ"].Value}\n" +
                           $"Hợp đồng: {selectedRow.Cells["Hợp đồng"].Value}\n" +
                           $"Địa chỉ: {selectedRow.Cells["Địa chỉ"].Value}";

                string imgUrl = selectedRow.Cells["URL img"].Value?.ToString();
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    pictureBox1.ImageLocation = imgUrl;  
                }
                else
                {
                    pictureBox1.Image = null;  
                }
            }
        }
        private void datagrid_SelectionChanged(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0) 
            {
                DataGridViewRow selectedRow = datagrid.SelectedRows[0];

                if (selectedRow != null && selectedRow.Cells.Count > 0) 
                {
                   
                    rtb.Text = $"Mã NV: {selectedRow.Cells["Mã NV"].Value}\n" +
                               $"Họ tên: {selectedRow.Cells["Họ tên"].Value}\n" +
                               $"Năm sinh: {selectedRow.Cells["Năm sinh"].Value}\n" +
                               $"Giới tính: {selectedRow.Cells["Giới tính"].Value}\n" +
                               $"Bộ phận: {selectedRow.Cells["Bộ phận"].Value}\n" +
                               $"Chức vụ: {selectedRow.Cells["Chức vụ"].Value}\n" +
                               $"Hợp đồng: {selectedRow.Cells["Hợp đồng"].Value}\n" +
                               $"Địa chỉ: {selectedRow.Cells["Địa chỉ"].Value}";

                    string imgUrl = selectedRow.Cells["URL img"].Value?.ToString();
                    if (!string.IsNullOrEmpty(imgUrl))
                    {
                        pictureBox1.ImageLocation = imgUrl;  
                    }
                    else
                    {
                        pictureBox1.Image = null; 
                    }
                }
            }
        }
        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (datagrid.Rows.Count > 0) 
            {
                if (currentRowIndex <= 0)
                {
                    currentRowIndex = datagrid.Rows.Count - 1; 
                }
                else
                {
                    currentRowIndex--; 
                }

                if (datagrid.Rows[currentRowIndex] != null)
                {
                    datagrid.Rows[currentRowIndex].Selected = true;
                    datagrid.FirstDisplayedScrollingRowIndex = currentRowIndex; 
                    datagrid_SelectionChanged(sender, e);  
                }
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (datagrid.Rows.Count > 0) 
            {
                
                if (currentRowIndex >= datagrid.Rows.Count - 1)
                {
                    currentRowIndex = 0; 
                }
                else
                {
                    currentRowIndex++; 
                }

          
                if (datagrid.Rows[currentRowIndex] != null)
                {
                    datagrid.Rows[currentRowIndex].Selected = true;
                    datagrid.FirstDisplayedScrollingRowIndex = currentRowIndex; 
                    datagrid_SelectionChanged(sender, e);  
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Show();
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var obj = _repos.GetEmployees().FirstOrDefault(em => em.EmployeeId == datagrid.CurrentRow.Cells[0].Value.ToString());
            _repos.DeleteEmployee(obj);
            LoadGidNV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
