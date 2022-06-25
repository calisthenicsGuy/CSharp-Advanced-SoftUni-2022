using System;
using System.Linq;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowOfVanko = 0;
            int colOfVanko = 0;
            char[,] wall = GetBakery(ref rowOfVanko, ref colOfVanko);
            int countOfHole = 1;
            int countOfHitRod = 0;
            char displayCharacter = ' ';

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int previousRowOfVanko = rowOfVanko;
                int previousColOfVanko = colOfVanko;

                if (command == "up" && rowOfVanko - 1 >= 0)
                {
                    rowOfVanko--;
                }
                else if (command == "down" && rowOfVanko + 1 < wall.GetLength(0))
                {
                    rowOfVanko++;
                }
                else if (command == "left" && colOfVanko - 1 >= 0)
                {
                    colOfVanko--;
                }
                else if (command == "right" && colOfVanko + 1 < wall.GetLength(1))
                {
                    colOfVanko++;
                }
                else
                {
                    continue;
                }

                if (wall[rowOfVanko, colOfVanko] == 'R')
                {
                    rowOfVanko = previousRowOfVanko;
                    colOfVanko = previousColOfVanko;

                    countOfHitRod++;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }

                if (wall[rowOfVanko, colOfVanko] == '-')
                {
                    countOfHole++;
                    wall[rowOfVanko, colOfVanko] = '*';
                }
                else if (wall[rowOfVanko, colOfVanko] == 'C')
                {
                    countOfHole++;
                    displayCharacter = 'E';

                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHole} hole(s).");
                    PrintFinalStateOfWall(wall, rowOfVanko, colOfVanko, displayCharacter);
                    return;
                }
                else if (wall[rowOfVanko, colOfVanko] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{rowOfVanko}, {colOfVanko}]!");
                }
            }

            Console.WriteLine($"Vanko managed to make {countOfHole} hole(s) and he hit only {countOfHitRod} rod(s).");
            displayCharacter = 'V';
            PrintFinalStateOfWall(wall, rowOfVanko, colOfVanko, displayCharacter);
        }

        private static void PrintFinalStateOfWall(char[,] wall, int rowOfVanko, int colOfVanko, char displayCharacter)
        {
            wall[rowOfVanko, colOfVanko] = displayCharacter;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write($"{wall[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static char[,] GetBakery(ref int rowOfVanko, ref int colOfVanko)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                char[] singleRowInput = rowInput.ToCharArray();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = singleRowInput[col];

                    if (wall[row, col] == 'V')
                    {
                        wall[row, col] = '*';
                        rowOfVanko = row;
                        colOfVanko = col;
                    }
                }
            }

            return wall;
        }
    }
}