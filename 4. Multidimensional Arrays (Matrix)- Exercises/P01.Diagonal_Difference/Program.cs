using System;
using System.Linq;

namespace P01.Diagonal_Difference
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            { 
                int[] singleRowInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = singleRowInput[col];
                }
            }

            int sumOfPrimaryDiagonalOfMatrix = 0;
            int sumOfSecondaryDiagonalOfMatrix = 0;

            int tempCol = matrix.GetLength(1) - 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumOfPrimaryDiagonalOfMatrix += matrix[row, row];
                sumOfSecondaryDiagonalOfMatrix += matrix[row, tempCol];
                tempCol--;
            }

            Console.WriteLine($"{Math.Abs(sumOfPrimaryDiagonalOfMatrix - sumOfSecondaryDiagonalOfMatrix)}");
        }
    }
}
