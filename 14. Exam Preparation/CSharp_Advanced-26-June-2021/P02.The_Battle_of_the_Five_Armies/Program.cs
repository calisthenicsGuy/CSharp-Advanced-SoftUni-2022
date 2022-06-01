using System;

namespace P02.The_Battle_of_the_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorOfArmy = int.Parse(Console.ReadLine());
            int sizeOfTheMap = int.Parse(Console.ReadLine());
            if (sizeOfTheMap < 5 || sizeOfTheMap > 20)
            {
                return;
            }

            string[,] map = new string[sizeOfTheMap, sizeOfTheMap];
            int[] parametersOfArmy = new int[2];
            int[] parametersOfMordor = new int[2];

            for (int row = 0; row < map.GetLength(0); row++)
            {
                string singleRowInput = Console.ReadLine();
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = singleRowInput[col].ToString();

                    if (map[row, col] == "A")
                    {
                        parametersOfArmy[0] = row;
                        parametersOfArmy[1] = col;
                        map[row, col] = "-";
                    }
                    if (map[row, col] == "M")
                    {
                        parametersOfMordor[0] = row;
                        parametersOfMordor[1] = col;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                int rowOfSpawn = int.Parse(command[1]);
                int colOfSpawn = int.Parse(command[2]);
                armorOfArmy--;

                map[rowOfSpawn, colOfSpawn] = "O";

                if (direction == "up" && parametersOfArmy[0] - 1 >= 0)
                {
                    parametersOfArmy[0]--;
                }
                else if (direction == "down" && parametersOfArmy[0] + 1 < map.GetLength(0))
                {
                    parametersOfArmy[1]++;
                }
                else if (direction == "left" && parametersOfArmy[1] - 1 >= 0)
                {
                    parametersOfArmy[1]--;
                }
                else if (direction == "right" && parametersOfArmy[1] + 1 < map.GetLength(0))
                {
                    parametersOfArmy[1]++;
                }


                if (map[parametersOfArmy[0], parametersOfArmy[1]] == "O")
                {
                    armorOfArmy -= 2;
                }
                if (map[parametersOfArmy[0], parametersOfArmy[1]] == "M")
                {
                    map[parametersOfArmy[0], parametersOfArmy[1]] = "-";
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armorOfArmy}");
                    break;
                }

                if (armorOfArmy <= 0)
                {
                    Console.WriteLine($"The army was defeated at {parametersOfArmy[0]};{parametersOfArmy[1]}.");
                    map[parametersOfArmy[0], parametersOfArmy[1]] = "X";
                    break;
                }
            }


            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.Write($"{map[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
