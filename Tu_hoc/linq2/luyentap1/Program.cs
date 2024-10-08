
namespace luyentap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var giangViens = GetGiangVien();
            Print(giangViens.OrderBy(s=>s.Ma));


        }

 

        static void Print(IEnumerable<GiangVien> giangViens)
        {
            foreach (var vien in giangViens)
            {
                Print(vien);
            }
        }
        static void Print(GiangVien giangVien)
        {
            Console.WriteLine($"Ma giang vien: {giangVien.Ma}, Ten giang vien: {giangVien.Ten}, Khoa: {giangVien.Khoa} ");
        }
        static IEnumerable<GiangVien> GetGiangVien()
        {
            return new GiangVien[]
            {
                new GiangVien()
                {
                    Ma = "123abc",
                    Ten = "Le Thi Phuong",
                    Khoa = "Toan"
                },
                new GiangVien()
                {
                    Ma = "23dfsa",
                    Ten = "Tran Quang Quan",
                    Khoa = "Cong Nghe Thong Tin"
                },
                new GiangVien()
                {
                    Ma = "123abc",
                    Ten = "Le Thi Ngan",
                    Khoa = "Tai Chinh Cong"
                }

            };
        }
    }
}
