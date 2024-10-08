using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton
{
    internal class AccessCounter
    {
        private int couter;
        private static AccessCounter accessCounter = new AccessCounter();
        public int Couter { get; }
        public int Inc()
        {   
            couter++;
            return couter;
        }

        public static AccessCounter GetIntance()
        {
            return accessCounter;
        }
    }
}
