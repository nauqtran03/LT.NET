using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvn_bai2
{
    internal class Student : Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string NativePlace { get; set; }
        public string Id { get; set; }

        public Student() { }

        public Student(string name, int age, string nativePlace, string id)
        {
            Name = name;
            Age = age;
            NativePlace = nativePlace;
            Id = id;
        }

        public void Input()
        {
            Console.Write("Nhập tên: ");
            Name = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Nhập quê quán: ");
            NativePlace = Console.ReadLine();
            Console.Write("Nhập ID: ");
            Id = Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine("Tên: " + Name);
            Console.WriteLine("Tuổi: " + Age);
            Console.WriteLine("Quê quán: " + NativePlace);
            Console.WriteLine("ID: " + Id);
        }

    }
}
