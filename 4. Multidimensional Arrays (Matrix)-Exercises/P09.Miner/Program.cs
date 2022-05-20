using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.Miner
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            string[] commandArray = Console.ReadLine().Split().ToArray();
            char[,] matrix = new char[rows, cols];
            ReadTheMatrix(rows, cols, matrix);

            int rowStart = 0;
            int colStart = 0;
            bool foundStart = false;
            for (int row = 0; row < rows; row++) // validate the matrix
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != '*'
                        && matrix[row, col] != 'e'
                        && matrix[row, col] != 'c'
                        && matrix[row, col] != 's')
                    {
                        return;
                    }

                    else if (matrix[row, col] == 's' && foundStart == false)
                    {
                        rowStart = row;
                        colStart = col;
                        foundStart = true;
                    }

                    else if (foundStart == true && matrix[row, col] == 's')
                    {
                        return;
                    }
                }
            }

            char start = matrix[rowStart, colStart];
            int currentRow = 0;
            int currentCol = 0;
            bool theEndOfTheRoad = false;
            for (int i = 0; i < commandArray.Length; i++)
            {
                string direction = commandArray[i];

                if (direction == "up") // command is Up
                {
                    if (rowStart - 1 >= 0)
                    {
                        MoveUp(matrix, ref rowStart, ref colStart, out currentRow, out currentCol, ref theEndOfTheRoad);
                    }
                }

                else if (direction == "down") // command is Down
                {
                    if (rowStart + 1 <= rows - 1)
                    {
                        MoveDown(matrix, ref rowStart, ref colStart, out currentRow, out currentCol, ref theEndOfTheRoad);
                    }
                }

                else if (direction == "left") // command is Left
                {
                    if (colStart - 1 >= 0)
                    {
                        MoveLeft(matrix, ref rowStart, ref colStart, out currentRow, out currentCol, ref theEndOfTheRoad);
                    }
                }

                else if (direction == "right") // command is Right
                {
                    if (colStart + 1 < cols)
                    {
                        MoveRight(matrix, ref rowStart, ref colStart, out currentRow, out currentCol, ref theEndOfTheRoad);
                    }
                }

                if (theEndOfTheRoad)
                {
                    break;
                }
            }

            PrintTheResult(matrix, currentRow, currentCol, theEndOfTheRoad);
        }

        private static bool CheckRoad(char[,] matrix, int currentRow, int currentCol, bool theEndOfTheRoad)
        {
            if (matrix[currentRow, currentCol] == 'c')
            {
                matrix[currentRow, currentCol] = '*';
            }

            else if (matrix[currentRow, currentCol] == 'e')
            {
                theEndOfTheRoad = true;
                //break;
            }

            return theEndOfTheRoad;
        }

        private static void MoveUp(char[,] matrix, ref int rowStart, ref int colStart, out int currentRow, out int currentCol, ref bool theEndOfTheRoad)
        {
            currentRow = rowStart - 1;
            currentCol = colStart;

            theEndOfTheRoad = CheckRoad(matrix, currentRow, currentCol, theEndOfTheRoad);

            rowStart = currentRow;
            colStart = currentCol;
        }


        private static void MoveDown(char[,] matrix, ref int rowStart, ref int colStart, out int currentRow, out int currentCol, ref bool theEndOfTheRoad)
        {
            currentRow = rowStart + 1;
            currentCol = colStart;

            theEndOfTheRoad = CheckRoad(matrix, currentRow, currentCol, theEndOfTheRoad);

            rowStart = currentRow;
            colStart = currentCol;
        }

        private static void MoveRight(char[,] matrix, ref int rowStart, ref int colStart, out int currentRow, out int currentCol, ref bool theEndOfTheRoad)
        {
            currentRow = rowStart;
            currentCol = colStart + 1;

            theEndOfTheRoad = CheckRoad(matrix, currentRow, currentCol, theEndOfTheRoad);

            rowStart = currentRow;
            colStart = currentCol;
        }

        private static void MoveLeft(char[,] matrix, ref int rowStart, ref int colStart, out int currentRow, out int currentCol, ref bool theEndOfTheRoad)
        {
            currentRow = rowStart;
            currentCol = colStart - 1;

            theEndOfTheRoad = CheckRoad(matrix, currentRow, currentCol, theEndOfTheRoad);

            rowStart = currentRow;
            colStart = currentCol;
        }

        private static void PrintTheResult(char[,] matrix, int currentRow, int currentCol, bool theEndOfTheRoad)
        {
            if (theEndOfTheRoad == true)
            {
                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
            }

            else
            {
                int countCoals = 0;
                foreach (var cell in matrix)
                {
                    if (cell == 'c')
                    {
                        countCoals++;
                    }
                }

                if (countCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                }

                else if (countCoals > 0)
                {
                    Console.WriteLine($"{countCoals} coals left. ({currentRow}, {currentCol})");
                }
            }
        }

        private static void ReadTheMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] currentLine = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }
    }
}
