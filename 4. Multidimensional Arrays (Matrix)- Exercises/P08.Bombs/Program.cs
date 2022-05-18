using System;
using System.Linq;

namespace P08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] singleRowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = singleRowInput[col];
                }
            }

            int[] coordinatesOfBombs = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < coordinatesOfBombs.Length; i += 2)
            {
                int row = coordinatesOfBombs[i];
                int col = coordinatesOfBombs[i + 1];

                int value = matrix[row, col];

                if (matrix[row, col] <= 0)
                {
                    continue;
                }

                //up
                if (IsInRange(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= value;
                }

                //down
                if (IsInRange(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= value;
                }

                //left
                if (IsInRange(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= value;
                }

                //right
                if (IsInRange(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= value;
                }

                //leftUpDiagonal
                if (IsInRange(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= value;
                }

                //rightUpDiagonal
                if (IsInRange(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= value;
                }

                //leftDownDiagonal
                if (IsInRange(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= value;
                }

                //rightDownDiagonal
                if (IsInRange(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= value;
                }

                matrix[row, col] = 0;
            }

            int countOfAliveCells = 0;
            int sumOfAliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countOfAliveCells++;
                        sumOfAliveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }


        private static bool IsInRange(int[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));
        }
    }
}
