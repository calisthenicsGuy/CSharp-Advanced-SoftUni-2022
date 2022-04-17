using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P08.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parentheses = new Stack<char>();

            string sequenceOfParentheses = Console.ReadLine();

            bool isBalanced = true;
            foreach (char parenthese in sequenceOfParentheses)  
            {
                if (parenthese == '(' ||
                    parenthese == '{' ||
                    parenthese == '[')
                {
                    parentheses.Push(parenthese);
                    continue;
                }

                if (parentheses.Count == 0)
                { 
                    isBalanced = false;
                    break;
                }

                if (parenthese == ')' && parentheses.Peek() == '(')
                {
                    parentheses.Pop();
                }
                else if (parenthese == '}' && parentheses.Peek() == '{')
                {
                    parentheses.Pop();
                }
                else if (parenthese == ']' && parentheses.Peek() == '[')
                {
                    parentheses.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }


            if (!isBalanced || parentheses.Count > 0) 
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
