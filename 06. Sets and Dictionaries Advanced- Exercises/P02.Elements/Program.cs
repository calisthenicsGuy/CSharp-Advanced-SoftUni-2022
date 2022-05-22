using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int set1Lnegth = input[0];
            int set2Lnegth = input[1];
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            set1 = AddElements(set1, set1Lnegth);
            set2 = AddElements(set2, set2Lnegth);

            foreach (int number in set1)
            {
                if (set2.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }

        private static HashSet<int> AddElements(HashSet<int> set, int length)
        {
            for (int i = 0; i < length; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }

            return set;
        }
    }
}
