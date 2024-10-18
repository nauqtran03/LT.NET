using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;
namespace bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Đếm số lần xuất hiện cua chu cai trong file.");
            Console.WriteLine("Nhập tên file.");
            string nameFile = Console.ReadLine();
            Console.WriteLine("Nhập chứ cái cần đếm: ");
            string letter = Console.ReadLine();
            StreamReader myfile;
            myfile = File.OpenText(nameFile);
            string line;
            int count = 0;
            do
            {
                line = myfile.ReadLine();
                if (line != null)
                {
                    for (int i = 0; i< line.Length; i++)
                    {
                        if (line.Substring(i,1) == letter)
                        {
                            count++;
                        }
                    }
                }
            }while (line != null);
            myfile.Close();
            Console.WriteLine($"Số lần xuất hiện cua chữ cái trong file là: {0}", count);
            Console.ReadKey();
        }
    }
}
