using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>
                (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bottles = new Stack<int>
                (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalWastedLitters = 0;
            while (cups.Count != 0 && bottles.Count != 0)
            {
                int currentBottleValue = bottles.Pop();
                int currentCupCapacity = cups.Dequeue();

                if (currentBottleValue - currentCupCapacity >= 1)
                {
                    totalWastedLitters += currentBottleValue - currentCupCapacity;
                    continue;
                }

                currentCupCapacity -= currentBottleValue;
                while (currentCupCapacity > 0 && bottles.Count != 0)
                {
                    currentBottleValue = bottles.Pop();

                    if (currentBottleValue - currentCupCapacity >= 1)
                    {
                        totalWastedLitters += currentBottleValue - currentCupCapacity;
                        break;
                    }

                    currentCupCapacity -= currentBottleValue;
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {totalWastedLitters}");
        }
    }
}
