using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton1
{
    internal class AccessCouter1
    {
        private int couter = 0;
        private static AccessCouter1 accessCouter1 = new(); 

        public int Couter { get; }
        public int Inc()
        {
            couter++;
            return couter;
        }
        public static AccessCouter1 GetIntance1()
        {
            return accessCouter1;
        }

    }
}
