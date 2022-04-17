using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = tokens[0];
            int s = tokens[1];
            int x = tokens[2];

            int[] numbersToAdd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] actualNumbersToAdd = numbersToAdd.Take(n).ToArray();
            Queue<int> numbers = new Queue<int>(actualNumbersToAdd);

            for (int i = 1; i <= s; i++)
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                numbers.Dequeue();
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
