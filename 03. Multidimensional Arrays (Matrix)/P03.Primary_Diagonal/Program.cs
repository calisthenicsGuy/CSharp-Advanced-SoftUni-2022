using System;
using System.Linq;

namespace P03.Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquare = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfSquare, sizeOfSquare];

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

            int sumOfPrimaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumOfPrimaryDiagonal += matrix[row, row];
            }

            Console.WriteLine(sumOfPrimaryDiagonal);
        }
    }
}
