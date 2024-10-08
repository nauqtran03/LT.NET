namespace bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DanhSachSinhVien danhSachSinhVien = new DanhSachSinhVien();
            Console.Write("Nhap so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine());
            for (int i =0; i< n; i++)
            {
                Console.WriteLine($"Nhap thong tin sinh vien thu {i+1}: ");
                SinhVien sinhvien = new SinhVien();
                sinhvien.NhapThongTin();
                danhSachSinhVien.ThemSinhVien(sinhvien);
            }
            danhSachSinhVien.HienThiDanhSach();
        }
    }
}
