using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface11
{
    internal class DatabaseReadable : IReadable
    {
        public string Name => "Le Thi Ngan";

        public int ReadInt()
        {
            
            return 100;
        }

        public string ReadString()
        {
            
            return "ABCDEFGH";
        }
    }
}
