using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinhVien sv1 = new SinhVien();
            sv1.Ma = "SV001";
            sv1.HoTen = "Tran Quang Quan";
            sv1.QueQuan = "Ha Noi";
            sv1.Khoa = 10;

            Console.WriteLine("Sinh viên 1:");
            Console.WriteLine("Mã sinh viên: {0}", sv1.Ma);
            Console.WriteLine("Họ tên: {0}", sv1.HoTen);
            Console.WriteLine("Quê quán: {0}", sv1.QueQuan);
            Console.WriteLine("Khóa: {0}", sv1.Khoa);
            sv1.TrangThai();

            Console.WriteLine();

            SinhVien sv2 = new SinhVien("SV002", "Le Thi Ngan", "Thanh Hoa", 12);

            Console.WriteLine("Sinh viên 2:");
            Console.WriteLine("Mã sinh viên: {0}", sv2.Ma);
            Console.WriteLine("Họ tên: {0}", sv2.HoTen);
            Console.WriteLine("Quê quán: {0}", sv2.QueQuan);
            Console.WriteLine("Khóa: {0}", sv2.Khoa);
            sv2.TrangThai();

            Console.ReadLine();
        }
    }
}
