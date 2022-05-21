using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ")
                .ToList();

            Action<List<string>> action = Join2;

            // Console.WriteLine(string.Join("\n", names));
            // Join2(names);
            action(names);
        }

        static void Join2(List<string> list)
        {
            foreach (string name in list)
            {
                Console.WriteLine(name);
            }
        }
    }
}
