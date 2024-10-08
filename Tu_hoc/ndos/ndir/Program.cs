namespace ndir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = "C:\\";

                var dir = new DirectoryInfo(path);
                var directories = dir.GetDirectories();
                foreach (var d in directories)
                {
                    Console.WriteLine($"{d.LastWriteTime.ToString("MM/dd/yyyy")}{d.LastWriteTime.ToString("HH:mm")} <DIR> {d.Name}");
                }

                var files = dir.GetFiles();
                foreach (var item in files)
                {
                    Console.WriteLine($"{item.LastWriteTime.ToString("MM/dd/yyyy")}{item.LastWriteTime.ToString("HH:mm")}     {item.Length:#,###}     {item.Name}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
