using System;
using System.Linq;

namespace P06.Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            InitializationMatrix(ref matrix);
            ManipulatingMatrix(ref matrix);
            PrintOutput(matrix);
        }

        public static void InitializationMatrix(ref int[,] matrix)
        {
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
        }

        public static void PrintOutput(int[,] matrix)
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

        public static void ManipulatingMatrix(ref int[,] matrix)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    Console.WriteLine($"Invalid coordinates");
                    continue;
                }

                if (action == "Add")
                {
                    matrix[row, col] += value;
                }
                else if (action == "Subtract")
                {
                    matrix[row, col] -= value;
                }
            }
        }
    }
}
