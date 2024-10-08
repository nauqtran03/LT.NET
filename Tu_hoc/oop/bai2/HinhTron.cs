using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    public class HinhTron : HinhHoc 
    {
        public double BanKinh { get; set; }
        public HinhTron(double banKinh)
        {
            BanKinh = banKinh;
        }
        public override double TinhDienTich()
        {
            return BanKinh*Math.PI*3.14;
        }

    }
}
