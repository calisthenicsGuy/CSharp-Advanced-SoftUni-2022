using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = tokens[0];
                string subAction = tokens[1];
                string argument = tokens[2];

                Func<string, string, bool> predicate = Case(subAction);
                people = Where(predicate, people, action, argument).ToList();
            }

            PrintOutput(people);
        }

        private static void PrintOutput(List<string> people)
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else if (people.Count != 0)
            {
                Console.WriteLine($"{String.Join(", ", people)} are going to the party!");
            }
        }

        static Func<string, string, bool> Case(string subAction)
        {
            Func<string, string, bool> predicate = null;
            if (subAction == "StartsWith")
            {
                predicate = (name, startWith) => name.StartsWith(startWith);
            }
            else if (subAction == "EndsWith")
            {
                predicate = (name, endWith) => name.EndsWith(endWith);
            }
            else if (subAction == "Length")
            {
                predicate  = (name, length) => name.Length == int.Parse(length);
            }

            return predicate;
        }

        static List<string> Where
            (Func<string, string, bool> predicate, List<string> list, string action, string argument)
        {
            var newList = new List<string>();
            if (action == "Double")
            {
                foreach (string name in list)
                {
                    newList.Add(name);
                    if (predicate(name, argument))
                    {
                        newList.Add(name);
                    }
                }
            }
            else if (action == "Remove")
            {
                foreach (string name in list)
                {
                    if (predicate(name, argument))
                    {
                        continue;
                    }

                    newList.Add(name);
                }
            }

            return newList;
        }
    }
}
