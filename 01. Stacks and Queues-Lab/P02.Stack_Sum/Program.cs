using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(numbersInput);

            Operations(numbers);
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }

        public static void Operations(Stack<int> numbers)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string operation = commandArgs[0];

                if (operation.ToLower() == "add")
                {
                    AddElements(numbers, operation, commandArgs);
                }
                else if (operation.ToLower() == "remove")
                {
                    RemoveElement(numbers, commandArgs, operation);
                }
            }
        }

        public static void RemoveElement(Stack<int> numbers, string[] commandArgs, string operation)
        {
            int count = int.Parse(commandArgs[1]);

            if (count > numbers.Count())
            {
                return;
            }

            for (int i = 1; i <= count; i++)
            {
                numbers.Pop();
            }
        }

        public static void AddElements(Stack<int> numbers, string operation, string[] commandArgs)
        {
            int firstNum = int.Parse(commandArgs[1]);
            int secondNum = int.Parse(commandArgs[2]);

            numbers.Push(firstNum);
            numbers.Push(secondNum);
        }
    }
}
