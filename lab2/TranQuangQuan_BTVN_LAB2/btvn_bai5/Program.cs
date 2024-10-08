using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvn_bai5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập vào một xâu ký tự: ");
            string inputString = Console.ReadLine();
            Console.WriteLine("\nXâu ký tự vừa nhập: " + inputString);

            // 2. Đếm số chữ thường và chữ hoa
            int lowercaseCount = 0, uppercaseCount = 0;
            foreach (char c in inputString)
            {
                if (char.IsLower(c)) lowercaseCount++;
                else if (char.IsUpper(c)) uppercaseCount++;
            }
            Console.WriteLine($"\nSố chữ thường: {lowercaseCount}");
            Console.WriteLine($"Số chữ hoa: {uppercaseCount}");

            // 3. Đếm số từ trong xâu vừa nhập
            string[] words = inputString.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            Console.WriteLine($"\nSố từ trong xâu: {wordCount}");

            // 4. Đếm số phụ âm và nguyên âm trong xâu vừa nhập
            int vowelCount = 0, consonantCount = 0;
            string vowels = "aeiouAEIOU";
            foreach (char c in inputString)
            {
                if (char.IsLetter(c))
                {
                    if (vowels.Contains(c))
                        vowelCount++;
                    else
                        consonantCount++;
                }
            }
            Console.WriteLine($"\nSố nguyên âm: {vowelCount}");
            Console.WriteLine($"Số phụ âm: {consonantCount}");

            // 5. Nhập vào một xâu con và đếm số lần xuất hiện của xâu con trong xâu đã nhập
            Console.Write("\nNhập vào một xâu con: ");
            string subString = Console.ReadLine();
            int subStringCount = 0, index = 0;
            while ((index = inputString.IndexOf(subString, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                subStringCount++;
                index += subString.Length;
            }
            Console.WriteLine($"\nSố lần xuất hiện của xâu con \"{subString}\" trong xâu đã nhập: {subStringCount}");

            // Đợi người dùng nhấn phím để kết thúc chương trình
            Console.ReadKey();
        }
    }
}
