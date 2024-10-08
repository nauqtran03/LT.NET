using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvn_bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();


            Console.Write("Nhập số lượng sinh viên: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");
                Student student = new Student();
                student.Input();
                students.Add(student);
            }

       
            Console.WriteLine("\nDanh sách sinh viên vừa nhập:");
            foreach (Student student in students)
            {
                student.Display();
                Console.WriteLine("--------------------------");
            }

    
            Console.WriteLine("\nThông tin sinh viên có tên là \"Nam\":");
            bool found = false;
            foreach (Student student in students)
            {
                if (student.Name.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                {
                    student.Display();
                    Console.WriteLine("--------------------------");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy sinh viên có tên là \"Nam\".");
            }

            Console.ReadKey();
        }
    }

}
