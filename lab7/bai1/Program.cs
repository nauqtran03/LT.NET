using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filePath = "test.txt";
            string input;
            string content = "";
           
            Console.WriteLine("Chương trình ghi file C#. ");
            StreamWriter myfile = File.AppendText(filePath);
            string line;
            do
            {
                Console.WriteLine("Nhập một đoạn text: ");
                line = Console.ReadLine();
                if(line != "")
                {
                    Console.WriteLine(line);
                }
            }while(line != "");
            myfile.Close();
            Console.ReadKey();  
        }
    }
}
