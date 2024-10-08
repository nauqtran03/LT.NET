using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai4_btvn
{
    internal class HanhKhach : Nguoi
    {
        public VeMayBay[] Ve { get; set; }
        public int SoLuong { get; set; }

        public HanhKhach() : base()
        {
            SoLuong = 0;
            Ve = null;
        }

        public HanhKhach(string hoten, string gioitinh, int tuoi, VeMayBay[] ve, int soluong) : base(hoten, gioitinh, tuoi)
        {
            Ve = ve;
            SoLuong = soluong;
        }

        ~HanhKhach() { }

      
        public void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập số lượng vé: ");
            SoLuong = int.Parse(Console.ReadLine());
            Ve = new VeMayBay[SoLuong];
            for (int i = 0; i < SoLuong; i++)
            {
                Ve[i] = new VeMayBay();
                Console.WriteLine($"Nhập thông tin vé thứ {i + 1}:");
                Ve[i].Nhap();
            }
        }

        public void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Số lượng vé: {SoLuong}");
            for (int i = 0; i < SoLuong; i++)
            {
                Ve[i].Xuat();
            }
        }

        public double TongTien()
        {
            double tong = 0;
            for (int i = 0; i < SoLuong; i++)
            {
                tong += Ve[i].GetGiaVe();
            }
            return tong;
        }
    }
}
