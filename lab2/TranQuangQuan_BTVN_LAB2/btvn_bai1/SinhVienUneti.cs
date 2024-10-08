using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvn_bai1
{
    abstract class SinhVienUneti
    {

        public string HoTen { get; set; }
        public string Nganh { get; set; }

        public SinhVienUneti(string hoTen, string nganh)
        {
            HoTen = hoTen;
            Nganh = nganh;
        }

        public abstract double GetDiem();

        public string GetXepLoaiHL()
        {
            double diem = GetDiem();
            if (diem >= 9) return "Xuất sắc";
            else if (diem >= 7) return "Giỏi";
            else if (diem >= 5) return "Khá";
            else return "Yếu";
        }

        public void Xuat()
        {
            Console.WriteLine("Họ tên: " + HoTen);
            Console.WriteLine("Ngành: " + Nganh);
            Console.WriteLine("Điểm: " + GetDiem());
            Console.WriteLine("Xếp loại học lực: " + GetXepLoaiHL());
        }
    }
}
