namespace Ngay15_8
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            int x = 7;
            int y = 10;
            Console.WriteLine("Main.x = " + x);
            Console.WriteLine("Main.y = " + y);
            
            Print(x,ref y);
            //In ra sau khi dung ref
            Console.WriteLine("x= " + x);
            Console.WriteLine("y= " + y);

            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            PrintFibo(n);
        
        }
        static int Print(int x, ref int y)
        {
            x = 100;
            y = 200;
            Console.WriteLine(x+" "+y);

            return x + y;
        }

        static int Fibonaci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return Fibonaci(n-1) + Fibonaci(n-2);
        }
        static void PrintFibo(int n)
        {
            Console.WriteLine("Day fibobaci: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(" " + Fibonaci(i));
            }
        }
    }
}
