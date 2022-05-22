using System;
using System.Linq;

namespace P02.Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }

        static int MyParse(string numberAsString)
        {
            int number = 0;

            foreach (char digit in numberAsString)
            {
                number *= 10;
                number += digit - '0';
            }

            return number;
        }
    }
}
