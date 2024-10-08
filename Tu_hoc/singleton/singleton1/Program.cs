namespace singleton1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(AccessCouter1.GetIntance1().Inc());
            }
        }
    }
}
