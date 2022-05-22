using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<int, int, bool> predicate = (nameSum, num) => nameSum >= num;
            Console.WriteLine(GetName(names, predicate, number));
        }

        static string GetName(List<string> list, Func<int, int, bool> predicate, int num)
        {

            foreach (string name in list)
            {
                int sum = GetSumOfName(name);
                if (predicate(sum, num))
                {
                    return name;
                }
            }

            return null;
        }

        static int GetSumOfName(string name)
        {
            int sum = 0;
            foreach (char ch in name)
            {
                sum += (int)ch;
            }

            return sum;
        }
    }
}
