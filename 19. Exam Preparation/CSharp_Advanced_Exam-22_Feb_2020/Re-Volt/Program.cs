using System;

namespace Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            int[] parametersOfPlayer = new int[2];
            char[,] field = GetField(size, parametersOfPlayer);

            bool isWin = false;
            for (int i = 1; i <= countOfCommands; i++)
            {
                string command = Console.ReadLine();
                int[] previousParametersOfPlayer = new int[2] { parametersOfPlayer[0], parametersOfPlayer[1]};

                parametersOfPlayer = Operations(parametersOfPlayer, command, field);

                while (field[parametersOfPlayer[0], parametersOfPlayer[1]] == 'B'
                    || field[parametersOfPlayer[0], parametersOfPlayer[1]] == 'T')
                {
                    if (field[parametersOfPlayer[0], parametersOfPlayer[1]] == 'B')
                    {
                        previousParametersOfPlayer = parametersOfPlayer;
                        parametersOfPlayer = Operations(parametersOfPlayer, command, field);
                    }

                    if (field[parametersOfPlayer[0], parametersOfPlayer[1]] == 'T')
                    {
                        parametersOfPlayer[0] = previousParametersOfPlayer[0];
                        parametersOfPlayer[1] = previousParametersOfPlayer[1];
                    }

                    if (field[parametersOfPlayer[0], parametersOfPlayer[1]] == 'F')
                    {
                        field[parametersOfPlayer[0], parametersOfPlayer[1]] = 'f';
                        Console.WriteLine("Player won!");
                        isWin = true;
                        break;
                    }
                }

                if (isWin)
                {
                    break;
                }
                if (field[parametersOfPlayer[0], parametersOfPlayer[1]] == 'F')
                {
                    field[parametersOfPlayer[0], parametersOfPlayer[1]] = 'f';
                    Console.WriteLine("Player won!");
                    isWin = true;
                    break;
                }
            }

            if (!isWin)
            {
                field[parametersOfPlayer[0], parametersOfPlayer[1]] = 'f';
                Console.WriteLine("Player lost!");
            }

            PrintFinalStageOfField(field);
        }



        private static void PrintFinalStageOfField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static int[] Operations(int[] parametersOfPlayer, string command, char[,] field)
        {
            if (command == "down")
            {
                if (parametersOfPlayer[0] == field.GetLength(0) - 1)
                {
                    parametersOfPlayer[0] = 0;
                }
                else
                {
                    parametersOfPlayer[0]++;
                }
            }
            else if (command == "up")
            {
                if (parametersOfPlayer[0] == 0)
                {
                    parametersOfPlayer[0] = field.GetLength(0) - 1;
                }
                else
                {
                    parametersOfPlayer[0]--;
                }
            }
            else if (command == "left")
            {
                if (parametersOfPlayer[1] == 0)
                {
                    parametersOfPlayer[1] = field.GetLength(1) - 1;
                }
                else
                {
                    parametersOfPlayer[1]--;
                }
            }
            else if (command == "right")
            {
                if (parametersOfPlayer[1] == field.GetLength(1) - 1)
                {
                    parametersOfPlayer[1] = 0;
                }
                else
                {
                    parametersOfPlayer[1]++;
                }
            }

            return parametersOfPlayer;
        }

        private static char[,] GetField(int size, int[] parametersOfPlayer)
        {
            char[,] field = new char[size, size];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] singleRowInput = input.ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = singleRowInput[col];

                    if (field[row, col] == 'f')
                    {
                        parametersOfPlayer[0] = row;
                        parametersOfPlayer[1] = col;

                        field[row, col] = '-';
                    }
                }
            }

            return field;
        }
    }
}
