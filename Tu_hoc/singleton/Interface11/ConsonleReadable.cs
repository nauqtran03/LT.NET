using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Interface11
{
    internal class ConsonleReadable : IReadable
    {
        public string Name => "Tran Quang Quan";

        public int ReadInt()
        {
            Console.Write("Nhap int: ");
            return int.Parse(Console.ReadLine());
        }

        public string ReadString()
        {
            Console.Write("Nhap string: ");
            return Console.ReadLine();
        }
    }
}
