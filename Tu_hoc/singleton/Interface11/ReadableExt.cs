using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface11
{
    internal static class ReadableExt
    {
        public static void WriteName( this IReadable readable)
        {
            Console.WriteLine(readable.Name);
        }
    }
}
