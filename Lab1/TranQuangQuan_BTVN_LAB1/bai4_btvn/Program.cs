using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai4_btvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<HanhKhach> danhSachHanhKhach = new List<HanhKhach>();

            Console.Write("Nhập số lượng hành khách: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin hành khách thứ {i + 1}:");
                HanhKhach khach = new HanhKhach();
                khach.Nhap();
                danhSachHanhKhach.Add(khach);
            }

            Console.WriteLine("\nDanh sách hành khách và số tiền phải trả:");
            foreach (var khach in danhSachHanhKhach)
            {
                khach.Xuat();
                Console.WriteLine($"Tổng số tiền: {khach.TongTien()}\n");
            }

            var danhSachSapXep = danhSachHanhKhach.OrderByDescending(khach => khach.TongTien()).ToList();
            Console.WriteLine("Danh sách hành khách sau khi sắp xếp theo tổng tiền giảm dần:");
            foreach (var khach in danhSachSapXep)
            {
                khach.Xuat();
                Console.WriteLine($"Tổng số tiền: {khach.TongTien()}\n");
            }
            Console.ReadLine();
        }
    }
}
