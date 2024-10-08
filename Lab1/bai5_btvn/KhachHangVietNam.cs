using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai5_btvn
{
    internal class KhachHangVietNam : KhachHang
    {
        public string LoaiKhachHang { get; set; }
        public int DinhMuc { get; set; }

        public KhachHangVietNam() : base()
        {
            LoaiKhachHang = "";
            DinhMuc = 0;
        }

        public KhachHangVietNam(string maKhachHang, string hoTen, int soLuong, double donGia, string ngayHoaDon, string loaiKhachHang, int dinhMuc)
            : base(maKhachHang, hoTen, soLuong, donGia, ngayHoaDon)
        {
            LoaiKhachHang = loaiKhachHang;
            DinhMuc = dinhMuc;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập loại khách hàng: ");
            LoaiKhachHang = Console.ReadLine();
            Console.Write("Nhập định mức: ");
            DinhMuc = int.Parse(Console.ReadLine());
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loại khách hàng: {LoaiKhachHang}, Định mức: {DinhMuc}");
        }

        public override double TinhThanhTien()
        {
            if (SoLuong <= DinhMuc)
                return SoLuong * DonGia;
            else
                return (DinhMuc * DonGia) + ((SoLuong - DinhMuc) * DonGia * 2);
        }
    }
}
