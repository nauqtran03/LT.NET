using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baisosanhchuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kiem tra chuoi con trong C#");

            string str = "Chuoi con trong C#";

      
            if (str.Contains("trong"))
            {
                Console.WriteLine("Tim thay chuoi con 'trong'.");
            }
            else
            {
                Console.WriteLine("Khong tim thay chuoi con 'trong'.");
            }

            Console.ReadKey();
        }

    }
}
