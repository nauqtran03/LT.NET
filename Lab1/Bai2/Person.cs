using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class Person
    {
        protected int age;
        public void LoiChao()
        {
            Console.WriteLine("Hello");
        }
        public void SetAge(int n) 
        {
            age = n;
        }
    }
}
