using System;
using System.Collections.Generic;
using System.Linq;

namespace Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rowOfBeaver = 0;
            int colOfBeaver = 0;
            int initialCountOfWoodBranches = 0;
            int countOfCollectedWoodBranches = 0;
            char[,] pond = GetPond(size, ref rowOfBeaver, ref colOfBeaver, ref initialCountOfWoodBranches);
            var woodBranches = new Stack<char>();

            string command;
            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                switch (command)
                {
                    case "up": MoveUp
                            (ref pond, ref rowOfBeaver, ref colOfBeaver, ref woodBranches, ref countOfCollectedWoodBranches);
                        break;
                    case "down": MoveDown
                            (ref pond, ref rowOfBeaver, ref colOfBeaver, ref woodBranches, ref countOfCollectedWoodBranches);
                        break;
                    case "left": MoveLeft
                            (ref pond, ref rowOfBeaver, ref colOfBeaver, ref woodBranches, ref countOfCollectedWoodBranches);
                        break;
                    case "right": MoveRight
                            (ref pond, ref rowOfBeaver, ref colOfBeaver, ref woodBranches, ref countOfCollectedWoodBranches);
                        break;
                    default:
                        break;
                }
            }

            if (initialCountOfWoodBranches == countOfCollectedWoodBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {woodBranches.Count} wood branches: " +
                    $"{string.Join(", ", woodBranches)}");
            }
            else if (initialCountOfWoodBranches != countOfCollectedWoodBranches)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. " +
                    $"There are {initialCountOfWoodBranches - countOfCollectedWoodBranches} branches left.");
            }

            pond[rowOfBeaver, colOfBeaver] = 'B';
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }
                Console.WriteLine();
            }
        }


        private static void MoveRight
            (ref char[,] pond, ref int rowOfBeaver, ref int colOfBeaver, ref Stack<char> woodBranches, ref int countOfCollectedWoodBranches)
        {
            if (colOfBeaver + 1 >= pond.GetLength(1))
            {
                if (woodBranches.Count != 0)
                {
                    woodBranches.Pop();
                }
                return;
            }

            colOfBeaver++;
            if (IsLowerCase(pond, rowOfBeaver, colOfBeaver))
            {
                WoodBranchesOperation(ref woodBranches, ref pond, rowOfBeaver, colOfBeaver);
                countOfCollectedWoodBranches++;
            }
            else if (pond[rowOfBeaver, colOfBeaver] == 'F')
            {
                if (colOfBeaver == pond.GetLength(1) - 1)
                {
                    colOfBeaver = 0;
                }
                else
                {
                    colOfBeaver = pond.GetLength(1) - 1;
                }
            }
        }

        private static void MoveLeft
            (ref char[,] pond, ref int rowOfBeaver, ref int colOfBeaver, ref Stack<char> woodBranches, ref int countOfCollectedWoodBranches)
        {
            if (colOfBeaver - 1 < 0)
            {
                if (woodBranches.Count != 0)
                {
                    woodBranches.Pop();
                }
                return;
            }

            colOfBeaver--;
            if (IsLowerCase(pond, rowOfBeaver, colOfBeaver))
            {
                WoodBranchesOperation(ref woodBranches, ref pond, rowOfBeaver, colOfBeaver);
                countOfCollectedWoodBranches++;
            }
            else if (pond[rowOfBeaver, colOfBeaver] == 'F')
            {
                if (colOfBeaver == 0)
                {
                    colOfBeaver = pond.GetLength(1) - 1;
                }
                else
                {
                    colOfBeaver = 0;
                }
            }
        }

        private static void MoveDown
            (ref char[,] pond, ref int rowOfBeaver, ref int colOfBeaver, ref Stack<char> woodBranches, ref int countOfCollectedWoodBranches)
        {
            if (rowOfBeaver + 1 >= pond.GetLength(0))
            {
                if (woodBranches.Count != 0)
                {
                    woodBranches.Pop();
                }
                return;
            }

            rowOfBeaver++;
            if (IsLowerCase(pond, rowOfBeaver, colOfBeaver))
            {
                WoodBranchesOperation(ref woodBranches, ref pond, rowOfBeaver, colOfBeaver);
                countOfCollectedWoodBranches++;
            }
            else if (pond[rowOfBeaver, colOfBeaver] == 'F')
            {
                if (rowOfBeaver == pond.GetLength(0) - 1)
                {
                    rowOfBeaver = 0;
                }
                else
                {
                    rowOfBeaver = pond.GetLength(0) - 1;
                }
            }
        }

        private static void MoveUp
            (ref char[,] pond, ref int rowOfBeaver, ref int colOfBeaver, ref Stack<char> woodBranches, ref int countOfCollectedWoodBranches)
        {
            if (rowOfBeaver - 1 < 0)
            {
                if (woodBranches.Count != 0)
                {
                    woodBranches.Pop();
                }
                return;
            }

            rowOfBeaver--;
            if (IsLowerCase(pond, rowOfBeaver, colOfBeaver))
            {
                WoodBranchesOperation(ref woodBranches, ref pond, rowOfBeaver, colOfBeaver);
                countOfCollectedWoodBranches++;
            }
            else if (pond[rowOfBeaver, colOfBeaver] == 'F')
            {
                if (rowOfBeaver == 0)
                {
                    rowOfBeaver = pond.GetLength(0) - 1;
                }
                else
                {
                    rowOfBeaver = 0;
                }
            }
        }

        private static char[,] GetPond(int size, ref int rowOfBeaver, ref int colOfBeaver, ref int initialCountOfWoodBranches)
        {
            char[,] pond = new char[size, size];

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] singleRowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = singleRowInput[col];

                    if (pond[row, col] == 'B')
                    {
                        rowOfBeaver = row;
                        colOfBeaver = col;
                        pond[row, col] = '-';
                    }
                    else if (IsLowerCase(pond, row, col))
                    {
                        initialCountOfWoodBranches++;
                    }
                }
            }

            return pond;
        }

        private static void WoodBranchesOperation
            (ref Stack<char> woodBranches, ref char[,] pond, int rowOfBeaver, int colOfBeaver)
        {
            woodBranches.Push(pond[rowOfBeaver, colOfBeaver]);
            pond[rowOfBeaver, colOfBeaver] = '-';
        }

        private static bool IsLowerCase(char[,] pond, int row, int col)
        {
            return (int)pond[row, col] >= 97 && (int)pond[row, col] <= 122;
        }
    }
}