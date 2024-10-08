namespace linq2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudents();
            Print(students.Where(s =>s.YoB ==2003));
            Console.WriteLine("=================================");
            Print(students.OrderBy(s =>s.YoB== 2003).OrderBy(s => s.Name));

           /* foreach (var studentName in students.OrderBy(s =>s.Name))
            {
                Console.WriteLine(studentName.Name);
            }*/
            foreach (var studentName in students.OrderBy(s => s.Name).Select(s=>s.Name))
            {
                Console.WriteLine(studentName);
            }

        }
        static void Print(IEnumerable<Students> students)
        {
            foreach (var student in students)
            {
                Print(student);
            }
        }

        private static void Print(Students student)
        {
            Console.WriteLine($"Name: {student.Name}, City: {student.City}, YoB: {student.YoB}");
        }
        static IEnumerable<Students> GetStudents() 
        {
            return new Students[]
            {
                new Students()
                {
                    Name = "Tran Quang Quan",
                    City = "Thanh Hoa",
                    YoB = 2003
                },
                new Students()
                {
                    Name = "Le Thi Ngan",
                    City = "Thanh Hoa",
                    YoB = 2003
                },
                new Students()
                {
                    Name = "Tran Quang Hoan",
                    City = "Thanh Hoa",
                    YoB = 1971
                }
            };

        }
    }
}
