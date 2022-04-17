using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] magicNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = magicNumbers[0];
            int s = magicNumbers[1];
            int x = magicNumbers[2];

            int[] givenNumbersToAdd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] actualNumbersToAdd = givenNumbersToAdd
                .Take(n)
                .ToArray();

            Stack<int> numbers = new Stack<int>(actualNumbersToAdd);

            for (int i = 1; i <= s; i++)
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                numbers.Pop();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.OrderBy(x => x).FirstOrDefault());
            }
        }
    }
}
