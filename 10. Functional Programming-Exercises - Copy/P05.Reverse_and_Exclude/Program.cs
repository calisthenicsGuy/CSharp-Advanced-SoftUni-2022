using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            numbers = Reverse(numbers).ToList();
            Func<int, int, bool> predicate = IsDivideByN;
            numbers = Where(numbers, n, predicate).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> Reverse(List<int> list)
        {
            var newList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                newList.Add(list[list.Count - 1 - i]);
            }

            return newList;
        }

        static bool IsDivideByN(int number, int n) => number % n != 0;

        static List<int> Where(List<int> list, int n, Func<int, int, bool> predicate)
        {
            var newList = new List<int>();
            foreach (int num in list)
            {
                if (predicate(num, n))
                {
                    newList.Add(num);
                }
            }

            return newList;
        }
    }
}
