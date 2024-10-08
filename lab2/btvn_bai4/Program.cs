using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvn_bai4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập kích thước của ma trận vuông (n): ");
            int n = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Nhập phần tử tại [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // 2. Hiển thị ma trận
            Console.WriteLine("\nMa trận vừa nhập:");
            DisplayMatrix(matrix);

            // 3. Tính tổng các phần tử nằm trên đường chéo phụ của ma trận
            double sumSecondaryDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                sumSecondaryDiagonal += matrix[i, n - i - 1];
            }
            Console.WriteLine($"\nTổng các phần tử trên đường chéo phụ của ma trận: {sumSecondaryDiagonal}");

            // 4. Tìm số âm lớn nhất trên đường chéo chính của ma trận
            double? maxNegativeOnMainDiagonal = null;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] < 0 && (maxNegativeOnMainDiagonal == null || matrix[i, i] > maxNegativeOnMainDiagonal))
                {
                    maxNegativeOnMainDiagonal = matrix[i, i];
                }
            }

            if (maxNegativeOnMainDiagonal.HasValue)
            {
                Console.WriteLine($"\nSố âm lớn nhất trên đường chéo chính của ma trận: {maxNegativeOnMainDiagonal}");
            }
            else
            {
                Console.WriteLine("\nKhông có số âm trên đường chéo chính của ma trận.");
            }

            // 5. Đếm các phần tử của ma trận có giá trị chia hết cho 3 và 5
            int countDivisibleBy3And5 = 0;
            foreach (var item in matrix)
            {
                if (item % 3 == 0 && item % 5 == 0)
                {
                    countDivisibleBy3And5++;
                }
            }
            Console.WriteLine($"\nSố lượng phần tử của ma trận chia hết cho 3 và 5: {countDivisibleBy3And5}");

            // Đợi người dùng nhấn phím để kết thúc chương trình
            Console.ReadKey();
        }

        // Phương thức hiển thị ma trận
        static void DisplayMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
