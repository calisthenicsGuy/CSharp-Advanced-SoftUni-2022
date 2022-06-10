using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Beaver_at_Work
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] positionOfBeaver = new int[2];
            var branches = new Queue<char>();
            int initialCountOfBranches = 0;
            int countOfBranches = 0;
            char[,] pond = GetPond(size, ref positionOfBeaver, ref initialCountOfBranches);

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "right": 
                        Right(pond, positionOfBeaver, branches);
                        break;
                    case "left":
                        Left(pond, positionOfBeaver, branches);
                        break;
                    case "up":
                        Up(pond, positionOfBeaver, branches);
                        break;
                    case "down":
                        Down(pond, positionOfBeaver, branches);
                        break;
                    default:
                        break;
                }

                if ((int)pond[positionOfBeaver[0], positionOfBeaver[1]] >= 97 && 
                    (int)pond[positionOfBeaver[0], positionOfBeaver[1]] <= 122)
                {
                    branches.Enqueue(pond[positionOfBeaver[0], positionOfBeaver[1]]);
                    pond[positionOfBeaver[0], positionOfBeaver[1]] = '-';
                    countOfBranches++;
                }
            }

            pond[positionOfBeaver[0], positionOfBeaver[1]] = 'B';
            PrintingOutput(pond, countOfBranches, initialCountOfBranches, branches);
        }

        private static void Down(char[,] pond, int[] positionOfBeaver, Queue<char> branches)
        {
            if (positionOfBeaver[0] + 1 == pond.GetLength(0))
            {
                if (branches.Count != 0)
                {
                    branches.Dequeue();
                    return;
                }
            }
            positionOfBeaver[0]++;
            if (pond[positionOfBeaver[0], positionOfBeaver[1]] == 'F')
            {
                pond[positionOfBeaver[0], positionOfBeaver[1]] = '-';

                if (positionOfBeaver[0] + 1 == pond.GetLength(0))
                {
                    positionOfBeaver[0] = 0;
                }
                else
                {
                    positionOfBeaver[0] = pond.GetLength(0) - 1;
                }
            }
        }

        private static void Up(char[,] pond, int[] positionOfBeaver, Queue<char> branches)
        {
            if (positionOfBeaver[0] == 0)
            {
                if (branches.Count != 0)
                {
                    branches.Dequeue();
                    return;
                }
            }
            positionOfBeaver[0]--;
            if (pond[positionOfBeaver[0], positionOfBeaver[1]] == 'F')
            {
                pond[positionOfBeaver[0], positionOfBeaver[1]] = '-';

                if (positionOfBeaver[0] == 0)
                {
                    positionOfBeaver[0] = pond.GetLength(0) - 1;
                }
                else
                {
                    positionOfBeaver[0] = 0;
                }
            }
        }

        private static void Left(char[,] pond, int[] positionOfBeaver, Queue<char> branches)
        {
            if (positionOfBeaver[1] == 0)
            {
                if (branches.Count != 0)
                {
                    branches.Dequeue();
                    return;
                }
            }

            positionOfBeaver[1]--;
            if (pond[positionOfBeaver[0], positionOfBeaver[1]] == 'F')
            {
                pond[positionOfBeaver[0], positionOfBeaver[1]] = '-';

                if (positionOfBeaver[1] == 0)
                {
                    positionOfBeaver[1] = pond.GetLength(1) - 1;
                }
                else
                {
                    positionOfBeaver[1] = 0;
                }
            }
        }

        private static void Right(char[,] pond, int[] positionOfBeaver, Queue<char> branches)
        {
            if (positionOfBeaver[1] + 1 == pond.GetLength(1))
            {
                if (branches.Count != 0)
                {
                    branches.Dequeue();
                    return;
                }
            }

            positionOfBeaver[1]++;
            if (pond[positionOfBeaver[0], positionOfBeaver[1]] == 'F')
            {
                pond[positionOfBeaver[0], positionOfBeaver[1]] = '-';

                if (positionOfBeaver[1] + 1 == pond.GetLength(1))
                {
                    positionOfBeaver[1] = 0;
                }
                else
                {
                    positionOfBeaver[1] = pond.GetLength(1) - 1;
                }
            }
        }

        private static void PrintingOutput(char[,] pond, int countOfBranches, int initialCountOfBranches, Queue<char> branches)
        {
            if (countOfBranches == initialCountOfBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: " +
                    $"{string.Join(", ", branches)}.");
            }
            else if (countOfBranches != initialCountOfBranches)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. " +
                    $"There are {initialCountOfBranches - countOfBranches} branches left.");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static char[,] GetPond(int size, ref int[] positionOfBeaver, ref int initialCountOfBranches)
        {
            char[,] pond = new char[size, size];

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] singleRowInput = Console.ReadLine()
                    .Split(" ")
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = singleRowInput[col];

                    if (pond[row, col] == 'B')
                    {
                        positionOfBeaver[0] = row;
                        positionOfBeaver[1] = col;
                        pond[row, col] = '-';
                    }
                    else if ((int)pond[row, col] >= 97 &&
                    (int)pond[row, col] <= 122)
                    {
                        initialCountOfBranches++;
                    }
                }
            }

            return pond;
        }
    }
}
