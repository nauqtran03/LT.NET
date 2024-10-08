using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GiaoDichHangHoa giaoDich1 = new GiaoDichHangHoa();
            giaoDich1.hienThiThongTinGiaoDich();

            Console.WriteLine();

            GiaoDichHangHoa giaoDich2 = new GiaoDichHangHoa("MH001", "27/09/2024", 100.5);
            giaoDich2.hienThiThongTinGiaoDich();
        }
    }
}
