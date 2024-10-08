using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai5_btvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();

            // Nhập danh sách hóa đơn khách hàng
            Console.Write("Nhập số lượng khách hàng: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Chọn loại khách hàng (1 - Việt Nam, 2 - Nước ngoài): ");
                int loai = int.Parse(Console.ReadLine());

                KhachHang khachHang;

                if (loai == 1)
                {
                    khachHang = new KhachHangVietNam();
                }
                else
                {
                    khachHang = new KhachHangNuocNgoai();
                }

                khachHang.Nhap();
                danhSachKhachHang.Add(khachHang);
            }

            // b. Xuất danh sách các hóa đơn khách hàng
            Console.WriteLine("\nDanh sách hóa đơn khách hàng:");
            foreach (var kh in danhSachKhachHang)
            {
                kh.Xuat();
            }

            // c. Tính tổng số lượng điện tiêu thụ cho từng loại khách hàng
            int tongSoLuongVN = 0, tongSoLuongNN = 0;
            double tongTienNN = 0;

            foreach (var kh in danhSachKhachHang)
            {
                if (kh is KhachHangVietNam)
                {
                    tongSoLuongVN += kh.SoLuong;
                }
                else if (kh is KhachHangNuocNgoai)
                {
                    tongSoLuongNN += kh.SoLuong;
                    tongTienNN += kh.ThanhTien;
                }
            }

            Console.WriteLine($"\nTổng số lượng điện tiêu thụ của khách hàng Việt Nam: {tongSoLuongVN}");
            Console.WriteLine($"Tổng số lượng điện tiêu thụ của khách hàng nước ngoài: {tongSoLuongNN}");

            // d. Tính trung bình thành tiền của khách hàng nước ngoài
            double trungBinhThanhTienNN = tongTienNN / tongSoLuongNN;
            Console.WriteLine($"Trung bình thành tiền của khách hàng nước ngoài: {trungBinhThanhTienNN}");

            // e. Xuất ra các hóa đơn trong tháng 09/2020
            Console.WriteLine("\nCác hóa đơn trong tháng 09/2020:");
            foreach (var kh in danhSachKhachHang)
            {
                if (kh.NgayHoaDon.Contains("09/2020"))
                {
                    kh.Xuat();
                }
            }
        }
    }
}
