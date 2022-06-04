using System;
using System.Collections.Generic;
using System.Linq;

namespace Loot_box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var claimedItems = new List<int>();

            var firstLootBox = new Queue<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var secondLootBox = new Stack<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (firstLootBox.Count != 0 && secondLootBox.Count != 0)
            {
                int currElementFromFirstLootBox = firstLootBox.Peek();
                int currElementFromSecondLootBox = secondLootBox.Pop();

                int sumOfCurrTwoBoxElement = currElementFromFirstLootBox + currElementFromSecondLootBox;
                if (sumOfCurrTwoBoxElement % 2 == 0)
                {
                    claimedItems.Add(sumOfCurrTwoBoxElement);
                    firstLootBox.Dequeue();
                }
                else if (sumOfCurrTwoBoxElement % 2 == 1)
                {
                    firstLootBox.Enqueue(currElementFromSecondLootBox);
                }
            }
            ;

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else if (claimedItems.Sum() < 100)
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
