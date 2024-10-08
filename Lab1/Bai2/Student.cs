using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class Student : Person
    {
        public void ThongBaoTuoi() 
        {
            Console.WriteLine("Tuoi cua ban la : {0}", age);
        }
        public void GoToClass() 
        {
            Console.WriteLine("I'm go to class");
        }
    }
}
