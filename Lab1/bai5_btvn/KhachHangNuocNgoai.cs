using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai5_btvn
{
    internal class KhachHangNuocNgoai : KhachHang
    {
        public string QuocTich { get; set; }

        public KhachHangNuocNgoai() : base()
        {
            QuocTich = "";
        }

        public KhachHangNuocNgoai(string maKhachHang, string hoTen, int soLuong, double donGia, string ngayHoaDon, string quocTich)
            : base(maKhachHang, hoTen, soLuong, donGia, ngayHoaDon)
        {
            QuocTich = quocTich;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập quốc tịch: ");
            QuocTich = Console.ReadLine();
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Quốc tịch: {QuocTich}");
        }
    }
}
