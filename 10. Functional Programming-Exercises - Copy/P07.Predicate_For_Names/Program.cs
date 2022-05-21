using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            // Func<List<string>, int, Func<string, int, bool>, List<string>> predicate = FindAll;
            // Console.WriteLine(predicate(names, n, IsValidLength));
            Func<string, bool> isValidLength = name => name.Length <= n;
            names = FindAll(names, n, isValidLength).ToList();
            Console.WriteLine(string.Join("\n", names));

        }

        static List<string> FindAll(List<string> list, int n, Func<string, bool> match)
        {
            var newList = new List<string>();

            foreach (string name in list)
            {
                if (match(name))
                {
                    newList.Add(name);
                }
            }

            return newList;
        }
    }
}
