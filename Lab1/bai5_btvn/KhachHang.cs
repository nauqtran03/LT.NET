using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai5_btvn
{
    internal class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
        public string NgayHoaDon { get; set; }

        public KhachHang()
        {
            MaKhachHang = "";
            HoTen = "";
            SoLuong = 0;
            DonGia = 0;
            ThanhTien = 0;
            NgayHoaDon = "";
        }

        public KhachHang(string maKhachHang, string hoTen, int soLuong, double donGia, string ngayHoaDon)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            SoLuong = soLuong;
            DonGia = donGia;
            NgayHoaDon = ngayHoaDon;
            ThanhTien = TinhThanhTien();
        }

        public virtual void Nhap()
        {
            Console.Write("Nhập mã khách hàng: ");
            MaKhachHang = Console.ReadLine();
            Console.Write("Nhập họ tên khách hàng: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập số lượng điện tiêu thụ: ");
            SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhập đơn giá: ");
            DonGia = double.Parse(Console.ReadLine());
            Console.Write("Nhập ngày hóa đơn: ");
            NgayHoaDon = Console.ReadLine();
            ThanhTien = TinhThanhTien();
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Mã KH: {MaKhachHang}, Họ tên: {HoTen}, Số lượng: {SoLuong}, Đơn giá: {DonGia}, Thành tiền: {ThanhTien}, Ngày HĐ: {NgayHoaDon}");
        }

        public virtual double TinhThanhTien()
        {
            return SoLuong * DonGia;
        }
    }
}
