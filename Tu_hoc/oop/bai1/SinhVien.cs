using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
{
    public class SinhVien
    {
        public  string MaSinhVien { get; set; }
        public  string HoTen { get; set; }
        public  DateTime NgaySinh { get; set; }

        public void NhapThongTin()
        {
            Console.WriteLine("Nhap ma sinh vien: ");
            MaSinhVien = Console.ReadLine();
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh: ");
            string ngaySinh = Console.ReadLine();

            if (DateTime.TryParseExact(ngaySinh, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinhInput))
            {
                NgaySinh = ngaySinhInput;
            }
            else
            {
                Console.WriteLine("Dinh dang ngay sinh khong hop le!");
                NgaySinh = DateTime.MinValue;
            }
        }
        public void XuatThongTin()
        {
            Console.WriteLine($"Ma: {MaSinhVien}, Ten: {HoTen}, Ngay Sinh: {NgaySinh:dd/MM/yyyy}");
        }
    }
}
