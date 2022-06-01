using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dishes = new Dictionary<string, int>();

            var ingredients = new Queue<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var freshnessOfIngredients = new Stack<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (ingredients.Count != 0 && freshnessOfIngredients.Count != 0)
            {
                int currIngredients = ingredients.Dequeue();
                if (currIngredients == 0)
                {
                    continue;
                }
                int currFreshness = freshnessOfIngredients.Pop();

                int currFreshnessLevel = currFreshness * currIngredients;
                string dishToPrepare = null;

                if (currFreshnessLevel == 150)
                {
                    dishToPrepare = "Dipping sauce";
                }
                else if (currFreshnessLevel == 250)
                {
                    dishToPrepare = "Green salad";
                }
                else if (currFreshnessLevel == 300)
                {
                    dishToPrepare = "Chocolate cake";
                }
                else if (currFreshnessLevel == 400)
                {
                    dishToPrepare = "Lobster";
                }
                else
                {
                    currIngredients += 5;
                    ingredients.Enqueue(currIngredients);
                    continue;
                }


                if (!dishes.ContainsKey(dishToPrepare))
                {
                    dishes[dishToPrepare] = 0;
                }
                dishes[dishToPrepare]++;
            }

            if (dishes.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count != 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (KeyValuePair<string, int> dish in dishes.OrderBy(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"# {dish.Key} --> {dish.Value}");
            }
        }
    }
}
