using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._3C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (KeyValuePair<string, Dictionary<string, List<string>>> continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
