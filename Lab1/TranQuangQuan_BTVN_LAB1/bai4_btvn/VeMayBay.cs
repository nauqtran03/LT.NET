using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai4_btvn
{
    internal class VeMayBay
    {
        public string TenChuyen { get; set; }
        public string NgayBay { get; set; }
        public double GiaVe { get; set; }

        // Hàm tạo không tham số
        public VeMayBay()
        {
            TenChuyen = "";
            NgayBay = "";
            GiaVe = 0.0;
        }

        // Hàm tạo có tham số
        public VeMayBay(string tenchuyen, string ngaybay, double giave)
        {
            TenChuyen = tenchuyen;
            NgayBay = ngaybay;
            GiaVe = giave;
        }
        ~VeMayBay() { }

     
        public void Nhap()
        {
            Console.Write("Nhập tên chuyến bay: ");
            TenChuyen = Console.ReadLine();
            Console.Write("Nhập ngày bay: ");
            NgayBay = Console.ReadLine();
            Console.Write("Nhập giá vé: ");
            GiaVe = double.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"Chuyến bay: {TenChuyen}, Ngày bay: {NgayBay}, Giá vé: {GiaVe}");
        }

        public double GetGiaVe()
        {
            return GiaVe;
        }
    }
}
