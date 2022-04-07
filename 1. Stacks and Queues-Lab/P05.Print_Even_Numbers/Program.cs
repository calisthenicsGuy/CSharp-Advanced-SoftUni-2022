using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Where(i => i % 2 == 0)
            //    .ToArray();

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> nums = new Queue<int>();

            foreach (var number in input)
            {
                if (number % 2 == 0)
                {
                    nums.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
