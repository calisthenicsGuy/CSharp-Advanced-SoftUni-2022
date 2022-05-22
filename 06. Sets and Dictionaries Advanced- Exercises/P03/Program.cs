using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var set = new SortedSet<string>();
            for (int i = 1; i <= n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in elements)
                {
                    set.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
