using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_btvn
{
    internal class SinhVien
    {
        public string HoTen { get; set; }
        public string QueQuan { get; set; }
        public int NamSinh {get; set; }
        public double DiemTongKet { get; set; }

        public SinhVien()
        {

        }
        public SinhVien(string hoTen, string queQuan, int namSinh, double diemTongKet)
        {
            this.HoTen = hoTen;
            this.QueQuan = queQuan;
            this.NamSinh = namSinh;
            this.DiemTongKet = diemTongKet;
        }
        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            this.HoTen = Console.ReadLine();
            Console.Write("Nhap que quan: ");
            this.QueQuan = Console.ReadLine();
            Console.Write("Nhap nam sinh: ");
            this.NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem tong ket: ");
            this.DiemTongKet= double.Parse(Console.ReadLine());
        }
        public void Xuat()
        {
            Console.WriteLine($"Thong tin sinh vien: \nHo ten: {HoTen} \nQue Quan: {QueQuan} \nNam Sinh: {NamSinh} \nDiem Tong Ket: {DiemTongKet}");
        }
    }
}
