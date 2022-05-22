using System;
using System.Linq;

namespace P04.Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquare = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquare, sizeOfTheSquare];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] singleRow = input.ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = singleRow[col];
                }
            }

            char searchedSharacter = char.Parse(Console.ReadLine());
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == searchedSharacter)
                    {
                        Console.WriteLine($"({row}, {col})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{searchedSharacter} does not occur in the matrix");
        }
    }
}
