using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> func = (i, x) => i % x == 0;
            numbers = FindNumbers(func, n, numbers).ToList();
            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> FindNumbers(Func<int, int, bool> func, int n, List<int> list)
        {
            var newList = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDivisible = true;
                foreach (int num in list)
                {
                    if (!func(i, num))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    newList.Add(i);
                }
            }

            return newList;
        }
    }
}
