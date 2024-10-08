namespace lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = [231,43,21,45,534,2,1];
            Console.WriteLine("Mang sau khi sap xep la: ");
            Array.Sort(arr ,(a,b) => a.CompareTo(b));
            Print(i=>true ,arr);

            Console.WriteLine("Kiem tra xem cos 123 trong mang khong: ");
            bool contains = Array.Exists(arr, x => x == 123);
            Console.WriteLine(contains ? "Co" : "Khong");
        }
       static void Print(Func<int,bool> f, int[] arr)
        {
            foreach(int i in arr)
            {
                if (f(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
