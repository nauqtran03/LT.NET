using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
{
    public class DanhSachSinhVien
    {
        public List<SinhVien> DanhSach { get; set; } = new List<SinhVien>();
        public void ThemSinhVien(SinhVien sinhVien)
        {
            DanhSach.Add(sinhVien);
        }
        public void HienThiDanhSach()
        {
            Console.WriteLine("Danh sach sinh vien: ");
            foreach (var s in DanhSach) 
            {
                s.XuatThongTin();
            }
        }
    }
}
