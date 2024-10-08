namespace linq1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var dataSoure = GetIntNumber();
            Print(dataSoure);

            var ns = from n in dataSoure where n>0 select n;
            Print(ns);
            var ns1 = from n in dataSoure 
                      where n > 0 &&  n%2 == 0
                      select n;
            Print(ns1);


            var ns2 = dataSoure.Where(n => n < 0 && n % 2 == 1);
            Print(ns2);

            Console.WriteLine(ns1.Sum());
        }

        static IEnumerable<int> GetIntNumber()
        {
            var ns = new[] { 12, 132,-32, 321, 1243, 53,-1, 21, 43, 32, 232 };
            return ns;
        }

        static void Print(IEnumerable<int> vlaues)
        {
            Console.WriteLine("----------------------------------------------");
            foreach (var vlaue in vlaues)
            { 
                Console.WriteLine(vlaue);
            }
        }
    }
}
