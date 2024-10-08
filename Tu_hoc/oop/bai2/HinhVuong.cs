using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    public class HinhVuong : HinhHoc
    {
        public double Canh { get; set; }
        public HinhVuong(double canh)
        {
            Canh = canh;
        }
        public override double TinhDienTich()
        {
            return Canh*Canh;
        }
    }
}
