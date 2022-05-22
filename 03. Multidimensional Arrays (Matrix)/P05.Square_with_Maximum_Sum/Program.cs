using System;
using System.Linq;

namespace P05.Square_with_Maximum_Sum
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

            Initialization(ref matrix, rows, cols);
            FindAndPrintTheBiggestSubMatrix(matrix, rows, cols);
    }

        public static void Initialization(ref int[,] matrix, int rows, int cols)
        {
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
        }

        public static void FindAndPrintTheBiggestSubMatrix(int[,] matrix, int rows, int cols)
        {
            int subMatrixWithBiggestSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + 2 - 1 < rows && col + 2 - 1 < cols)
                    {
                        int tempSubMatrixWithBiggestSum = 0;
                        for (int currRow = row; currRow < row + 2; currRow++)
                        {
                            for (int currCol = col; currCol < col + 2; currCol++)
                            {
                                tempSubMatrixWithBiggestSum += matrix[currRow, currCol];
                            }
                        }

                        if (tempSubMatrixWithBiggestSum > subMatrixWithBiggestSum)
                        {
                            subMatrixWithBiggestSum = tempSubMatrixWithBiggestSum;
                            maxRowIndex = row;
                            maxColIndex = col;
                        }
                    }
                }
            }


            for (int row = maxRowIndex; row < maxRowIndex + 2; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(subMatrixWithBiggestSum);
        }
    }
}
