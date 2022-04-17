using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Sum_Matrix_Columns
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
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = singleRowInput[col];
                }
            }

            List<int> sumOfColumsInMatrix = new List<int>();
            for (int col = 0; col < cols; col++)
            {
                int tempSumOfColums = 0;
                for (int row = 0; row < rows; row++)
                {
                    tempSumOfColums += matrix[row, col];
                }

                sumOfColumsInMatrix.Add(tempSumOfColums);
            }

            Console.WriteLine(string.Join("\n", sumOfColumsInMatrix));
        }
    }
}
