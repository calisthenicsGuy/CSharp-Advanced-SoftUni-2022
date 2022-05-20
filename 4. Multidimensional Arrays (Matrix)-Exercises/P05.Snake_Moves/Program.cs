using System;
using System.Linq;

namespace P05.Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            char[,] matrix = new char[n, m];
            string text = Console.ReadLine();

            int currChar = 0;
            bool leftToRigth = true;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (leftToRigth)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = text[currChar++];

                        if (currChar == text.Length)
                        {
                            currChar = 0;
                        }
                    }

                    leftToRigth = false;
                }
                else if (!leftToRigth)
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        matrix[row, col] = text[currChar++];

                        if (currChar == text.Length)
                        {
                            currChar = 0;
                        }
                    }

                    leftToRigth = true;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
