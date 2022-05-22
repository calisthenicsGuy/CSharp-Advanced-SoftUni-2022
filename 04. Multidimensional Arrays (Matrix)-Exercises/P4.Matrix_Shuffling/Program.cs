using System;
using System.Linq;

namespace P4.Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = parameters[0];
            int cols = parameters[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] singleRowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = singleRowInput[col];
                }
            }

            ManipulatingMatrix(matrix, rows, cols);
        }

        public static void ManipulatingMatrix(string[,] matrix, int rows, int cols)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!IsValidCommand(tokens, matrix, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int tempRow1 = int.Parse(tokens[1]);
                int tempCol1 = int.Parse(tokens[2]);
                int tempRow2 = int.Parse(tokens[3]);
                int tempCol2 = int.Parse(tokens[4]);

                string a = matrix[tempRow1, tempCol1];
                string b = matrix[tempRow2, tempCol2];

                matrix[tempRow1, tempCol1] = b;
                matrix[tempRow2, tempCol2] = a;

                PrintMatrix(matrix);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidCommand(string[] tokens, string[,] matrix, int rows, int cols)
        {
            if (tokens[0] != "swap" || tokens.Length != 5 ||
                    int.Parse(tokens[1]) >= rows || int.Parse(tokens[3]) >= rows ||
                    int.Parse(tokens[2]) >= cols || int.Parse(tokens[4]) >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
