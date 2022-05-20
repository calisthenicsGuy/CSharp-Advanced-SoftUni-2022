using System;
using System.Linq;
using System.Collections.Generic;

namespace P10.Radioactive_Mutant_Vampire_Bunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];

            char[,] field = new char[row, col];

            int[] starPsn = FillElements(row, col, field);
            int playerRow = starPsn[0];
            int playerCol = starPsn[1];

            //this stack will hold the bunnies cordinates
            Stack<int> bunnies = new Stack<int>();

            //check if we go at the end of the field
            bool won = false;

            string comands = Console.ReadLine();
            const int MOVE = 1;


            for (int c = 0; c < comands.Length; c++)
            {
                char comand = comands[c];

                field[playerRow, playerCol] = '.';

                if (comand == 'U')
                {
                    if (playerRow > 0)
                        playerRow -= MOVE;
                    else
                    {
                        won = true;
                    }
                    // ERROR: Player has only won when leaving the field
                    // playerRow == 0 => Player is still on the field
                    //if (playerRow == 0)
                    //    won = true;
                }
                else if (comand == 'D')
                {
                    if (playerRow < row - 1)
                        playerRow += MOVE;
                    else
                    {
                        won = true;
                    }
                    // ERROR: Player has only won when leaving the field
                    // playerRow == row - 1 => Player is still on the field
                    //if (playerRow == row - 1)
                    //    won = true;
                }
                else if (comand == 'L')
                {
                    if (playerCol > 0)
                        playerCol -= MOVE;
                    else
                    {
                        won = true;
                    }
                    // ERROR: Player has  only won when leaving the field
                    // playerCol == 0 => Player is still on the field
                    //if (playerCol == 0)
                    //    won = true;
                }
                else if (comand == 'R')
                {
                    if (playerCol < col - 1)
                        playerCol += MOVE;
                    else
                    {
                        won = true;
                    }
                    // ERROR: Player has  only won when leaving the field
                    // playerCol == col - 1 => Player is still on the field
                    //if (playerCol == col - 1)
                    //    won = true;
                }

                // First check if player has won, second if player has stepped unto a bunny,
                // third bunny grows unto player's position

                //if won is true he made it out of the field
                if (won)
                {
                    //we clone the bunnies one more time
                    BunniesGrow(row, col, field, bunnies);

                    //print the matrix and player psn
                    PrintMatrix(field, row, col);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                if (field[playerRow, playerCol] == 'B')
                {
                    BunniesGrow(row, col, field, bunnies);
                    PrintMatrix(field, row, col);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }

                //Grow the number of bunnies
                BunniesGrow(row, col, field, bunnies);

                //PrintMatrix(field, row, col);

                //if player is on B he is dead
                if (field[playerRow, playerCol] == 'B')
                {
                    PrintMatrix(field, row, col);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }
        }//main

        private static void BunniesGrow(int row, int col, char[,] field, Stack<int> bunnies)
        {
            //fill up the stack with all the bunnies cords 
            FaindBunny(field, bunnies);

            while (bunnies.Count != 0)
            {
                int bunnyCol = bunnies.Pop();
                int bunnyRow = bunnies.Pop();

                //bunny check if is possible to grow up
                //if (bunnyRow > 0 && field[bunnyRow - 1, bunnyCol] != 'B')
                if (bunnyRow > 0)
                {
                    field[bunnyRow - 1, bunnyCol] = 'B';
                }
                //bunny check if is possible to grow down 
                //if (bunnyRow < row - 1 && field[bunnyRow + 1, bunnyCol] != 'B')
                if (bunnyRow < row - 1)
                {
                    field[bunnyRow + 1, bunnyCol] = 'B';
                }
                //bunny check if is possible to grow left
                //if (bunnyCol > 0 && field[bunnyRow, bunnyCol - 1] != 'B')
                if (bunnyCol > 0)
                {
                    field[bunnyRow, bunnyCol - 1] = 'B';
                }
                //bunny check if is possible to grow right
                //if (bunnyCol < col - 1 && field[bunnyRow, bunnyCol + 1] != 'B')
                if (bunnyCol < col - 1)
                {
                    field[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        private static void FaindBunny(char[,] field, Stack<int> bunnies)
        {
            //read the field and save cords of all bunnies
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 'B')
                    {
                        bunnies.Push(i);
                        bunnies.Push(j);
                    }
                }
            }
        }

        private static int[] FillElements(int row, int col, char[,] field)
        {
            int[] result = new int[2];


            for (int i = 0; i < row; i++)
            {
                string temp = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    //fill up the char to the psn on the field
                    field[i, j] = temp[j];

                    //when we have the char "P" we save the cordinates
                    if (field[i, j] == 'P')
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }
            //return index 1 = start row ; 2 = start col ;
            return result;
        }

        private static void PrintMatrix(char[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
