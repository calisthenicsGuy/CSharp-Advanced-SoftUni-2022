using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Truffle_Hunter
{
    internal class Program
    {
        static void Main()
        {
            var collectedTruffles = new Dictionary<string, int>();
            collectedTruffles["Black"] = 0;
            collectedTruffles["White"] = 0;
            collectedTruffles["Summer"] = 0;

            int countOfEatenTruffles = 0;

            int sizeOfForest = int.Parse(Console.ReadLine());

            char[,] forest = GetForest(sizeOfForest);

            string commnad;
            while ((commnad = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = commnad
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = cmdArgs[0];
                int[] cordination = new int[2] 
                { int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]) };

                if (action == "Collect")
                {
                    if (forest[cordination[0], cordination[1]] == '-')
                    {
                        continue;
                    }

                    Collect(ref forest, ref collectedTruffles, cordination);
                }
                else if (action == "Wild_Boar")
                {
                    if (forest[cordination[0], cordination[1]] == '-')
                    {
                        continue;
                    }

                    string direction = cmdArgs[3];
                    countOfEatenTruffles = WildBoar(ref forest, direction, cordination);
                }
            }

            PrintOutput(forest, collectedTruffles, countOfEatenTruffles);
        }

        private static void PrintOutput
            (char[,] forest, Dictionary<string, int> collectedTruffles, int countOfEatenTruffles)
        {
            Console.WriteLine($"Peter manages to harvest {collectedTruffles["Black"]} black, " +
                $"{collectedTruffles["Summer"]} summer, and {collectedTruffles["White"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {countOfEatenTruffles} truffles.");

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int WildBoar
            (ref char[,] forest, string direction, int[] cordination)
        {
            int counter = 0;

            if (direction == "up")
            {
                while (cordination[0] >= 0)
                {
                    forest[cordination[0], cordination[1]] = '-';
                    counter++;

                    cordination[0] -= 2;
                }
            }
            else if (direction == "down")
            {
                while (cordination[0] < forest.GetLength(0))
                {
                    forest[cordination[0], cordination[1]] = '-';
                    counter++;

                    cordination[0] += 2;
                }
            }
            else if (direction == "left")
            {
                while (cordination[1] >= 0)
                {
                    forest[cordination[0], cordination[1]] = '-';
                    counter++;

                    cordination[1] -= 2;
                }
            }
            else if (direction == "right")
            {
                while (cordination[1] < forest.GetLength(0))
                {
                    forest[cordination[0], cordination[1]] = '-';
                    counter++;

                    cordination[1] += 2;
                }
            }

            return counter;
        }

        private static void Collect
            (ref char[,] forest, ref Dictionary<string, int> collectedTruffles, int[] cordination)
        {
            char currTruffle = forest[cordination[0], cordination[1]];
            forest[cordination[0], cordination[1]] = '-';


            switch (currTruffle)
            {
                case 'B':
                    collectedTruffles["Black"]++;
                    break;
                case 'S':
                    collectedTruffles["Summer"]++;
                    break;
                case 'W':
                    collectedTruffles["White"]++;
                    break;
                default:
                    break;
            }
        }

        private static char[,] GetForest(int sizeOfForest)
        {
            char[,] forest = new char[sizeOfForest, sizeOfForest];

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < forest.GetLength(1); col++)
                { 
                    forest[row, col] = input[col];
                }
            }

            return forest;
        }
    }
}
