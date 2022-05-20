using System;
using System.Linq;

namespace P02._2X2_Squares_in_Matrix
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

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] singleRowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = singleRowInput[col];
                }
            }

            int countOfEqualCells = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 2 <= rows && col + 2 <= cols)
                    {
                        int currCharacter = matrix[row, col];
                        if (currCharacter == matrix[row+1, col] &&
                            currCharacter == matrix[row, col+1] && 
                            currCharacter == matrix[row+1, col+1])
                        {
                            countOfEqualCells++;
                        }
                    }
                }
            }

            Console.WriteLine(countOfEqualCells);
        }
    }
}
