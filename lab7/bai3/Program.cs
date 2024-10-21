using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[] a = new int[100]; 
            int n;
            Console.Write(" n = ");
            Console.WriteLine("Nhập mảng vào tệp");
            n = int.Parse(Console.ReadLine()); for (int i = 0; i < n; i++)
            {

                Console.Write("a[{0}] = ", i);

                a[i] = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Nhập mảng vào tệp");
            string fileName = "DuLieu.txt"; 
            BinaryWriter wr = new BinaryWriter(new FileStream(fileName, FileMode.Create));
            for (int i = 0; i < n; i++) wr.Write(a[i]);
            wr.Close();
            Console.WriteLine("Đọc dãy số từ tệp nhị phân");
            BinaryReader rd = new BinaryReader(
            new FileStream(fileName, FileMode.Open));

            while (rd.BaseStream.Position != rd.BaseStream.Length)
            {

                Console.WriteLine(rd.ReadInt32());

            }

            rd.Close(); Console.ReadLine();
        }

    }

}

    