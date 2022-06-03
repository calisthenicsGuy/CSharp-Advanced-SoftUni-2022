using System;
using System.Collections.Generic;

namespace Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int WINING_OF_WHITE_PAWN = 0; // 8
            const int WINING_OF_BLACK_PAWN = 7; // 1

            var col1nChessBoard = new Dictionary<int, char>();
            // key - matrix index; value - chessboard letter
            col1nChessBoard[0] = 'a';
            col1nChessBoard[1] = 'b';
            col1nChessBoard[2] = 'c';
            col1nChessBoard[3] = 'd';
            col1nChessBoard[4] = 'e';
            col1nChessBoard[5] = 'f';
            col1nChessBoard[6] = 'g';
            col1nChessBoard[7] = 'h';

            var rowInChessBoard = new Dictionary<int, int>();
            // key - matrix index; value - chessboard index
            rowInChessBoard[0] = 8;
            rowInChessBoard[1] = 7;
            rowInChessBoard[2] = 6;
            rowInChessBoard[3] = 5;
            rowInChessBoard[4] = 4;
            rowInChessBoard[5] = 3;
            rowInChessBoard[6] = 2;
            rowInChessBoard[7] = 1;


            char[,] chessboard = new char[8, 8];

            int rowOfWhitePawn = 0;
            int colOfWhitePawn = 0;

            int rowOfBlackPawn = 0;
            int colOfBlackPawn = 0;

            GetChessBoardInput(ref chessboard, 
                ref rowOfWhitePawn, ref colOfWhitePawn, 
                ref rowOfBlackPawn, ref colOfBlackPawn);


            while (true)
            {
                rowOfWhitePawn--;

                if (colOfWhitePawn-1 == colOfBlackPawn || colOfWhitePawn+1 == colOfBlackPawn)
                {
                    Console.WriteLine($"Game over! White capture on " +
                        $"{col1nChessBoard[colOfBlackPawn]}" +
                        $"{rowInChessBoard[rowOfBlackPawn]}.");

                    Environment.Exit(0);
                }

                rowOfBlackPawn++;



                if (rowOfWhitePawn == WINING_OF_WHITE_PAWN)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at " +
                        $"{col1nChessBoard[colOfWhitePawn]}" +
                        $"{rowInChessBoard[rowOfWhitePawn]}.");

                    Environment.Exit(0);
                }
                else if (rowOfBlackPawn == WINING_OF_BLACK_PAWN)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at " +
                        $"{col1nChessBoard[colOfBlackPawn]}" +
                        $"{rowInChessBoard[rowOfBlackPawn]}.");

                    Environment.Exit(0);
                }
            }

        }

        private static void GetChessBoardInput(ref char[,] chessboard, 
            ref int rowOfWhitePawn, ref int colOfWhitePawn, 
            ref int rowOfBlackPawn, ref int colOfBlackPawn)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                string input = Console.ReadLine().ToLower();
                char[] singleRpwInput = input.ToCharArray();

                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = singleRpwInput[col];

                    if (chessboard[row, col] == 'w')
                    {
                        rowOfWhitePawn = row;
                        colOfWhitePawn = col;
                    }
                    else if (chessboard[row, col] == 'b')
                    {
                        rowOfBlackPawn = row;
                        colOfBlackPawn = col;
                    }
                }
            }
        }
    }
}
