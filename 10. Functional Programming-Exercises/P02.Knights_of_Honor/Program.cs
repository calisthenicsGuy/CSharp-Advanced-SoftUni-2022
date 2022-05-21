using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            // names.ForEach(x => Console.WriteLine($"Sir {x}"));
            // ForEach2(names);
            Action<List<string>> action = ForEach2;
            action(names);
        }

        static void ForEach2(List<string> list)
        {
            foreach (string name in list)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
