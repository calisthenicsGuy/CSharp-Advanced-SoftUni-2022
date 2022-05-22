using System;
using System.Linq;

namespace P01.Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = parameters[0];
            int cols = parameters[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] singleRowInput = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = singleRowInput[col];
                }
            }

            int sum = 0;
            // GetLength(0) - return the rows of matrix
            // GetLength(1) - return the cols of matrix
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        sum += matrix[row, col];
            //    }
            //}
            foreach (int item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
