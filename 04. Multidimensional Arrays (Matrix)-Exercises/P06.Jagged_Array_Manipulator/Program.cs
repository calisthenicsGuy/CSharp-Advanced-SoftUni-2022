using System;
using System.Linq;

namespace P06.Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] singleRowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[i] = new double[singleRowInput.Length];
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = singleRowInput[j];
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = Multiplier(jaggedArray[row]);
                    jaggedArray[row + 1] = Multiplier(jaggedArray[row + 1]);
                }
                else if (jaggedArray[row].Length != jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = Divider(jaggedArray[row]);
                    jaggedArray[row + 1] = Divider(jaggedArray[row + 1]);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(" ")
                    .ToArray();

                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if ((row >= 0 && row < jaggedArray.GetLength(0)) &&
                    (col >= 0 && col < jaggedArray[row].Length))
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        static double[] Multiplier(double[] array) =>
            array = array
                .Select(x => x * 2)
                .ToArray();

        static double[] Divider(double[] array) =>
            array = array
                .Select(x => x / 2)
                .ToArray();
    }
}
