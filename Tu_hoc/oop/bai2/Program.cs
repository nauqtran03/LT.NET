namespace bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao ban kinh hinh tron: ");
            double banKinh = double.Parse(Console.ReadLine());
            HinhTron hinhTron = new HinhTron(banKinh);
            Console.WriteLine($"Dien tich hinh tron: {hinhTron.TinhDienTich()}");


            Console.Write("Nhap vao canh hinh vuong: ");
            double canh = double.Parse(Console.ReadLine());
            HinhVuong hinhVuong = new HinhVuong(canh);
            Console.WriteLine($"Dien tich hinh tron: {hinhVuong.TinhDienTich()}");
            Console.ReadLine(); 
        }
    }
}
