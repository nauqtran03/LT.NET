using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvn_bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập số hàng của ma trận (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhập số cột của ma trận (m): ");
            int m = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Nhập phần tử tại [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // 2. Hiển thị ma trận
            Console.WriteLine("\nMa trận vừa nhập:");
            DisplayMatrix(matrix);

            // 3. Tìm số âm nhỏ nhất của ma trận
            double? minNegative = null;
            foreach (var item in matrix)
            {
                if (item < 0 && (minNegative == null || item < minNegative))
                {
                    minNegative = item;
                }
            }

            if (minNegative.HasValue)
            {
                Console.WriteLine($"\nSố âm nhỏ nhất trong ma trận: {minNegative}");
            }
            else
            {
                Console.WriteLine("\nKhông có số âm trong ma trận.");
            }

            // 4. Sắp xếp từng cột của ma trận theo thứ tự tăng dần
            SortColumns(matrix);
            Console.WriteLine("\nMa trận sau khi sắp xếp từng cột theo thứ tự tăng dần:");
            DisplayMatrix(matrix);

            // 5. Nhập số nguyên dương k, xóa cột thứ k của ma trận nếu có
            Console.Write("\nNhập cột cần xóa (k): ");
            int k = int.Parse(Console.ReadLine());
            if (k >= 1 && k <= m)
            {
                matrix = DeleteColumn(matrix, k - 1);
                m--; // Giảm số lượng cột sau khi xóa
                Console.WriteLine("\nMa trận sau khi xóa cột:");
                DisplayMatrix(matrix);
            }
            else
            {
                Console.WriteLine("\nKhông có cột này trong ma trận.");
            }

            // 6. Tính trung bình cộng các phần tử có giá trị chẵn trong ma trận
            double sumEven = 0;
            int countEven = 0;
            foreach (var item in matrix)
            {
                if (item % 2 == 0)
                {
                    sumEven += item;
                    countEven++;
                }
            }

            if (countEven > 0)
            {
                double average = sumEven / countEven;
                Console.WriteLine($"\nTrung bình cộng các phần tử có giá trị chẵn trong ma trận: {average}");
            }
            else
            {
                Console.WriteLine("\nKhông có phần tử chẵn trong ma trận.");
            }

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

        // Phương thức sắp xếp từng cột của ma trận theo thứ tự tăng dần
        static void SortColumns(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                // Lấy các phần tử trong cột j
                double[] column = new double[rows];
                for (int i = 0; i < rows; i++)
                {
                    column[i] = matrix[i, j];
                }

                // Sắp xếp cột
                Array.Sort(column);

                // Gán lại các phần tử đã sắp xếp vào ma trận
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = column[i];
                }
            }
        }

        // Phương thức xóa cột thứ k của ma trận
        static double[,] DeleteColumn(double[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] newMatrix = new double[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int newColIndex = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j != k)
                    {
                        newMatrix[i, newColIndex] = matrix[i, j];
                        newColIndex++;
                    }
                }
            }

            return newMatrix;
        }
    }
}
