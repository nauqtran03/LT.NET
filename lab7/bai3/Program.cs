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
            int[] a = new int[100];
            int n;

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            // Nhập mảng
            Console.WriteLine("Nhập mảng vào tệp:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }

            // Ghi mảng vào file nhị phân
            string fileName = "DuLieu.txt";
            using (BinaryWriter wr = new BinaryWriter(new FileStream(fileName, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    wr.Write(a[i]);
                }
            }

            Console.WriteLine("Đọc dãy số từ tệp nhị phân:");

            // Đọc mảng từ file nhị phân
            using (BinaryReader rd = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                try
                {
                    while (rd.BaseStream.Position != rd.BaseStream.Length)
                    {
                        // Đọc từng số nguyên từ file nhị phân và in ra
                        Console.WriteLine(rd.ReadInt32());
                    }
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("Đã đọc hết tệp.");
                }
            }

            Console.ReadLine();
        }

    }

}

    