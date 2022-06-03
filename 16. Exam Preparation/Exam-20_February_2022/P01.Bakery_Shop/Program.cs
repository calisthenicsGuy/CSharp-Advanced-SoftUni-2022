using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bakery_Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, int>();

            var water = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));
            var flour = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));

            while (water.Count != 0 && flour.Count != 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                double percentOfWater = (currWater / (currWater + currFlour)) * 100;
                double percentOfFlour = (currFlour / (currWater + currFlour)) * 100;

                if (percentOfWater == 50 && percentOfFlour == 50)
                {
                    if (!products.ContainsKey("Croissant"))
                    {
                        products["Croissant"] = 0;
                    }

                    products["Croissant"]++;
                }
                else if (percentOfWater == 40 && percentOfFlour == 60)
                {
                    if (!products.ContainsKey("Muffin"))
                    {
                        products["Muffin"] = 0;
                    }

                    products["Muffin"]++;
                }
                else if (percentOfWater == 30 && percentOfFlour == 70)
                {
                    if (!products.ContainsKey("Baguette"))
                    {
                        products["Baguette"] = 0;
                    }

                    products["Baguette"]++;
                }
                else if (percentOfWater == 20 && percentOfFlour == 80)
                {
                    if (!products.ContainsKey("Bagel"))
                    {
                        products["Bagel"] = 0;
                    }

                    products["Bagel"]++;
                }
                else
                {
                    if (currWater > currFlour)
                    {
                        water.Enqueue(currWater - currFlour);
                    }
                    else if (currWater < currFlour)
                    {
                        flour.Push(currFlour - currWater);
                    }

                    if (!products.ContainsKey("Croissant"))
                    {
                        products["Croissant"] = 0;
                    }

                    products["Croissant"]++;
                }
            }

            foreach (var product in products.OrderByDescending(v => v.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine($"Water left: None");
            }

            if (flour.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine($"Flour left: None");
            }
        }
    }
}
