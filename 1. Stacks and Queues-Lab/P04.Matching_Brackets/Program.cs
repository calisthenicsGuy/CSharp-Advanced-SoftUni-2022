using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();
            Stack<string> expresions = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndexOfExpresion = indexes.Peek();
                    string currExpr = input.Substring(indexes.Pop(), i - startIndexOfExpresion + 1);
                    expresions.Push(currExpr);
                }
            }

            string[] reverseExpr = expresions
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(("\n"), reverseExpr));
        }
    }
}
