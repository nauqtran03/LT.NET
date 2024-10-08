using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3_btvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VanDongVien p = new VanDongVien("Tran Quang Quan", 25, "Chay 100m", 70.6, 1.75 );
            p.HienThiThongTin();

            Console.Write("Nhap so luong van dong vien: ");
            int n = int.Parse( Console.ReadLine() );
            List<VanDongVien> danhSachVanDongVien = new List<VanDongVien>();
            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine($"Nhap thong tin van dong vien thu {i+1}: ");
                Console.Write("Ho Ten: ");
                string hoten = Console.ReadLine();
                Console.Write("Tuoi: ");
                int tuoi = int.Parse( Console.ReadLine() );
                Console.Write("Mon Thi Dau: ");
                string monthidau = Console.ReadLine();
                Console.Write("Can Nang: ");
                double cannang = double.Parse( Console.ReadLine() );
                Console.Write("Chieu cao: ");
                double chieucao = double.Parse( Console.ReadLine() );

                VanDongVien vdv = new VanDongVien(hoten, tuoi, monthidau, cannang, chieucao);
                danhSachVanDongVien.Add(vdv);

                Console.WriteLine("Danh sach van dong vien da nhap: ");
            }
            foreach (VanDongVien vdv in danhSachVanDongVien)
            {
                vdv.HienThiThongTin();
            }

            danhSachVanDongVien.Sort((x,y) => x.Tuoi.CompareTo(y.Tuoi));
            Console.WriteLine("Danh sach sau khi sap xep theo tuoi tang dan: ");
            foreach(VanDongVien vdv in danhSachVanDongVien)
            {
                vdv.HienThiThongTin();
            }
        }
    }
}
