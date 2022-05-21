using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();

            int[] givenNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startIndex = givenNumbers[0];
            int endIndex = givenNumbers[1];

            string command = Console.ReadLine();

            Predicate<int> predicate;
            switch (command)
            {
                case "even": predicate = IsEven;
                    break;
                case "odd": predicate = IsOdd;
                    break;
                default: return;
                    break;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                numbers.Add(i);
            }

            numbers = Where(numbers, predicate).ToList();
            Console.WriteLine(String.Join(" ", numbers));
        }

        static bool IsEven(int number) => number % 2 == 0;
        static bool IsOdd(int number) => number % 2 == 1;

        static List<int> Where(List<int> list, Predicate<int> predicate)
        {
            var newList = new List<int>();

            foreach (int number in list)
            {
                if (predicate(number))
                {
                    newList.Add(number);
                }
            }

            return newList;
        }
    }
}