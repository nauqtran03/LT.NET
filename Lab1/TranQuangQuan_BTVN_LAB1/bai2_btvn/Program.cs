using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_btvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> danhSachSinhVien = new List<SinhVien>();
            Console.Write("Nhap so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Nhap thong tin sinh vien thu {i+1}: ");
                SinhVien sv = new SinhVien();
                sv.Nhap();
                danhSachSinhVien.Add(sv);
            }

            Console.Write("Nhap thong tin sinh vien can sua: ");
            string tenCanSua = Console.ReadLine();
            SinhVien svCanSua = danhSachSinhVien.FirstOrDefault(sv=>sv.HoTen == tenCanSua);
            if (tenCanSua != null)
            {
                Console.Write("Nhap thong tin moi cho sinh vien: ");
                svCanSua.Nhap();
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }
            
            Console.Write("Nhap thon tin sinh vien can xoa: ");
            string tenCanXoa = Console.ReadLine();
            SinhVien svCanXoa = danhSachSinhVien.FirstOrDefault(sv=>sv.HoTen == tenCanXoa);
            if (tenCanXoa != null)
            {
                danhSachSinhVien.Remove(svCanXoa);
                Console.WriteLine("Xoa thanh cong");
            }
            else 
            {
                Console.WriteLine("Khong tim thay sinh vien");
            }

            Console.WriteLine("Danh sach sinh vien co que quan Nam Dinh: ");
            var svNamDinh = danhSachSinhVien.Where(sv=>sv.QueQuan == "Nam Dinh");
            foreach (var sv in svNamDinh)
            {
                sv.Xuat();
            }

            double maxDiem = danhSachSinhVien.Max(sv=>sv.DiemTongKet);
            Console.WriteLine("Danh sach sinh vien co diem tong ket lon nhat: ");
            var svDiemCaoNhat = danhSachSinhVien.Where(sv=>sv.DiemTongKet == maxDiem);
            foreach (var sv in svDiemCaoNhat)
            {
                sv.Xuat();
            }

            Console.ReadLine();
        }
    }
}
