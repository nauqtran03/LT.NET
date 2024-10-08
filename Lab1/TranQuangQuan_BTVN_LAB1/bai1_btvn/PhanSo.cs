using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1_btvn
{
    internal class PhanSo
    {
        private double tuso, mauso;
        public PhanSo() 
        {
            tuso = 0;
            mauso = 1;
        }
        ~PhanSo() { }
        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            tuso = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Nhap mau so(khac 0): ");
                mauso = int.Parse(Console.ReadLine());
            }
            while (mauso == 0);
        }
        public void Xuat()
        {
            Console.WriteLine("Phan so: {0}/{1}", tuso, mauso);
        }
        public PhanSo Cong(PhanSo ps)
        {
            PhanSo ketQua = new PhanSo();
            ketQua.tuso = this.tuso* ps.mauso + this.mauso* ps.tuso;
            ketQua.mauso = this.mauso*ps.mauso;
            return ketQua;
        }
        public PhanSo Tru(PhanSo ps)
        {
            PhanSo ketQua = new PhanSo();
            ketQua.tuso = this.tuso*ps.mauso - this.mauso * ps.tuso;
            ketQua.mauso = this.mauso * ps.mauso;
            return ketQua;
        }
        public PhanSo Nhan(PhanSo ps)
        {
            PhanSo ketQua = new PhanSo();
            ketQua.tuso = this.tuso * ps.tuso;
            ketQua.mauso = this.mauso * ps.mauso;
            return ketQua;
        }
        public PhanSo Chia(PhanSo ps)
        {
            PhanSo ketQua = new PhanSo();
            ketQua.tuso = this.tuso * ps.mauso;
            ketQua.mauso = this.mauso * ps.tuso;
            return ketQua;
        }
       public void XuatKetQua(String phepTinh, PhanSo ketQua)
        {
            Console.WriteLine($"{phepTinh}: {ketQua.tuso}/{ketQua.mauso}");
        }
    }
}
