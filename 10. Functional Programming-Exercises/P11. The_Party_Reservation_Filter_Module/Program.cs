using System;
using System.Collections.Generic;
using System.Linq;

namespace P11._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var filteredNames = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                Func<string, string, bool> predicate = Predicate(filterType);
                filteredNames = Operation(predicate, people, filteredNames, command, filterParameter).ToList();
            }

            people = RemoveFilteredNames(people, filteredNames).ToList();
            PrintOutput(people);
        }

        static List<string> RemoveFilteredNames(List<string> list, List<string> filteredNames)
        {
            var newList = new List<string>();

            foreach (string name in list)
            {
                if (filteredNames.Contains(name))
                {
                    continue;
                }

                newList.Add(name);
            }

            return newList;
        }

        static void PrintOutput(List<string> list)
        {
            Console.WriteLine(string.Join(" ", list));
        }

        static Func<string, string, bool> Predicate(string filterType)
        {
            Func<string, string, bool> predicate = null;
            if (filterType == "Starts with")
            {
                predicate = (name, startWith) => name.StartsWith(startWith);
            }
            else if (filterType == "Ends with")
            {
                predicate = (name, endsWith) => name.EndsWith(endsWith);
            }
            else if (filterType == "Length")
            {
                predicate = (name, length) => name.Length == int.Parse(length);
            }
            else if (filterType == "Contains")
            {
                predicate = (name, text) => name.Contains(text);
            }

            return predicate;
        }

        static List<string> Operation
            (Func<string, string, bool> predicate,
            List<string> list, List<string> filteredNames, 
            string command, string filterParameter)
        { 
            var newList = new List<string>(filteredNames);

            if (command == "Add filter")
            {
                foreach (string name in list)
                {
                    if (predicate(name, filterParameter) && !newList.Contains(name))
                    {
                        newList.Add(name);
                    }
                }
            }
            else if (command == "Remove filter")
            {
                foreach (string name in filteredNames)
                {
                    if (predicate(name, filterParameter))
                    {
                        newList.Remove(name);
                    }
                }
            }

            return newList;
        }
    }
}
