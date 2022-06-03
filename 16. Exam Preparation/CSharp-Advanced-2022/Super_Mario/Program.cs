using System;
using System.Linq;

namespace Super_Mario
{
    internal class Program
    {
        static void Main()
        {
            int livesOfMario = int.Parse(Console.ReadLine());
            int rowsOfMaze = int.Parse(Console.ReadLine());
            char[][] maze = new char[rowsOfMaze][];

            int[] parametersOfMario = new int[2];

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] mazeRow = input.ToCharArray();

                maze[row] = new char[mazeRow.Length];
                for (int col = 0; col < maze[row].Length; col++)
                {
                    maze[row][col] = mazeRow[col];
                    if (maze[row][col] == 'M')
                    {
                        parametersOfMario[0] = row;
                        parametersOfMario[1] = col;
                        maze[row][col] = '-';
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string moveCommand = tokens[0];
                int spawnRow = int.Parse(tokens[1]);
                int spawnCol = int.Parse(tokens[2]);

                maze[spawnRow][spawnCol] = 'B';
                livesOfMario--;

                if (moveCommand == "W" && parametersOfMario[0] - 1 >= 0)
                {
                    parametersOfMario[0]--;
                }
                else if (moveCommand == "S" && parametersOfMario[0] + 1 < maze.GetLength(0))
                {
                    parametersOfMario[0]++;   
                }
                else if (moveCommand == "A" && parametersOfMario[1] - 1 >= 0)
                {
                    parametersOfMario[1]--;
                }
                else if (moveCommand == "D" && parametersOfMario[1] + 1 < maze[parametersOfMario[0]].Length)
                {
                    parametersOfMario[1]++;
                }

                if (maze[parametersOfMario[0]][parametersOfMario[1]] == 'B')
                {
                    livesOfMario -= 2;
                    if (livesOfMario > 0)
                    {
                        maze[parametersOfMario[0]][parametersOfMario[1]] = '-';
                    }
                }

                if (maze[parametersOfMario[0]][parametersOfMario[1]] == 'P')
                {
                    maze[parametersOfMario[0]][parametersOfMario[1]] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
                    break;
                }

                if (livesOfMario <= 0)
                {
                    maze[parametersOfMario[0]][parametersOfMario[1]] = 'X';
                    Console.WriteLine($"Mario died at {parametersOfMario[0]};{parametersOfMario[1]}.");
                    break;
                }
            }

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                Console.WriteLine(String.Join("", maze[row]));
            }
        }
    }
}
