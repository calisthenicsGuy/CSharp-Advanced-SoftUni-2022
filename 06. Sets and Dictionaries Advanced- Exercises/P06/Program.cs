using System;
using System.Collections.Generic;

namespace P06_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string colorOfClothes = tokens[0];
                string[] newClothes = tokens[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(colorOfClothes))
                {
                    clothes[colorOfClothes] = new Dictionary<string, int>();
                }

                foreach (string newCloth in newClothes)
                {
                    if (!clothes[colorOfClothes].ContainsKey(newCloth))
                    {
                        clothes[colorOfClothes][newCloth] = 0;
                    }

                    clothes[colorOfClothes][newCloth]++;
                }
            }

            string[] clothToFind = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string color = clothToFind[0];
            string cloth = clothToFind[1];

            foreach (var colorOfCloth in clothes)
            {
                Console.WriteLine($"{colorOfCloth.Key} clothes:");

                bool isToSearch = false;
                if (colorOfCloth.Key == color)
                {
                    isToSearch = true;
                }

                foreach (var item in colorOfCloth.Value)
                {
                    if (item.Key == cloth && isToSearch)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
