using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lap trinh huong doi tuong trong C#");
            Console.WriteLine("----------------------------------\n");

            Person person = new Person();
            person.LoiChao();
            Console.WriteLine("----------------------------------\n");
            Student student = new Student();
            student.SetAge(18);
            student.LoiChao();
            student.ThongBaoTuoi();
            student.GoToClass();
            Console.WriteLine("----------------------------------\n");
            Teacher teacher = new Teacher();
            teacher.SetAge(30);
            teacher.LoiChao();
            teacher.GiangDay();
            
            Console.ReadLine();
        }
    }
}
