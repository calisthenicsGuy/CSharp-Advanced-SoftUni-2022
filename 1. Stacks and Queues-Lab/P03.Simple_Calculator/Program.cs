using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace P03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(input);

            // 1 + 2 + 3 - 5 - 3 + 67

            while (stack.Count > 1)
            {
                int firstTempNumber = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int secondTempNumber = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    stack.Push((firstTempNumber + secondTempNumber).ToString());
                }
                else if (operation == "-")
                {
                    stack.Push((firstTempNumber - secondTempNumber).ToString());
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
