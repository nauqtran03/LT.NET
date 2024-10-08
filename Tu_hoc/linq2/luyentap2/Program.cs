using System.ComponentModel.DataAnnotations;

namespace luyentap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudents();

            Print(students.Where(s=>s.StudentID==4));
            Print(students.OrderByDescending(s => s.Mark).FirstOrDefault());
            students.Count(s => s.Mark == 55);
            Print(students.Where(s=>s.StudentName.Contains("am") && s.City == "CA"));
            bool lonhon50 = students.All(s => s.Mark > 50);
            Console.WriteLine(lonhon50 ?"Pass":"Fail");
        }
        static void Print(IEnumerable<Student> Students)
        {
            foreach (var student in Students)
            {
                Print(student);
            }
        }
        static void Print(Student Student)
        {
            Console.WriteLine($"ID: {Student.StudentID}, Name: {Student.StudentName}, Mark: {Student.Mark}, City: {Student.City}");
        }
        static IEnumerable<Student> GetStudents()
        {
            return new Student[]
            {
                new Student()
                {
                    StudentID = 1,
                    StudentName = "John Nigel",
                    Mark = 73,
                    City = "NYC"
                },
                new Student()
                {
                    StudentID = 2,
                    StudentName = "Alex Roma",
                    Mark = 51,
                    City = "CA"
                },
                new Student()
                {
                    StudentID = 3,
                    StudentName = "Noha Shmail",
                    Mark = 88,
                    City = "CA"
                },
                new Student()
                {
                    StudentID = 4,
                    StudentName = "James Palatte",
                    Mark = 60,
                    City = "NYC"
                },
                new Student()
                {
                    StudentID = 5,
                    StudentName = "Ron Jenova",
                    Mark = 85,
                    City = "NYC"
                }
            };
        }
    }
}
