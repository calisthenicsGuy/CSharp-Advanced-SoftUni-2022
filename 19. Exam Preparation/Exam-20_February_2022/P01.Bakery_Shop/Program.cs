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
            products.Add("Croissant", 0);
            products.Add("Muffin", 0);
            products.Add("Baguette", 0);
            products.Add("Bagel", 0);

            var water = new Queue<double>
                (Console.ReadLine()
                .Split(" ")
                .Select(double.Parse));

            var flour = new Stack<double>
                (Console.ReadLine()
                .Split(" ")
                .Select(double.Parse));

            while (water.Count != 0 && flour.Count != 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                double ratio = currWater + currFlour;
                double percentageOfWater = currWater * 100 / ratio;
                double percentageOfFlour = currFlour * 100 / ratio;

                if (percentageOfWater == 50 && percentageOfFlour == 50)
                {
                    products["Croissant"]++;
                }
                else if (percentageOfWater == 40 && percentageOfFlour == 60)
                {
                    products["Muffin"]++;
                }
                else if (percentageOfWater == 30 && percentageOfFlour == 70)
                {
                    products["Baguette"]++;
                }
                else if (percentageOfWater == 20 && percentageOfFlour == 80)
                {
                    products["Bagel"]++;
                }
                else
                {
                    products["Croissant"]++;
                    currFlour = currFlour - currWater;
                    flour.Push(currFlour);
                }
            }

            foreach (KeyValuePair<string, int> product in products
                .Where(x => x.Value != 0).OrderByDescending(i => i.Value).ThenBy(x => x.Key))
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
