using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface11
{
    internal interface IReadable
    { 
        string Name {  get; }
        int ReadInt();
        string ReadString(); 
        
        static void WriteName(IReadable readable)
        {
            Console.WriteLine(readable.Name);
        }
    }
}
