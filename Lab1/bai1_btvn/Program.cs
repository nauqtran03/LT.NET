using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1_btvn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhanSo ps1 = new PhanSo();
            PhanSo ps2 = new PhanSo();

            Console.WriteLine("Nhap phan so thu nhat: ");
            ps1.Nhap();

            Console.WriteLine("Nhap phan so thu hai: ");
            ps2.Nhap();
            Console.WriteLine("--------------------------------------------");

            ps1.Xuat();
            ps2.Xuat();
            Console.WriteLine("--------------------------------------------");
         
            PhanSo tong = ps1.Cong(ps2);
            PhanSo hieu = ps1.Tru(ps2);
            PhanSo tich = ps1.Nhan(ps2);
            PhanSo thuong = ps1.Chia(ps2);

            tong.XuatKetQua("Tong: ", tong);
            hieu.XuatKetQua("Hieu: ", hieu);
            tich.XuatKetQua("Tich: ", tich);
            thuong.XuatKetQua("Thuong: ", thuong);
            Console.WriteLine("--------------------------------------------");
            Console.ReadLine();
        }
    }
}
