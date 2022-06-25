using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var existingLocations = new Dictionary<string, int>();
            existingLocations["Sink"] = 0;
            existingLocations["Oven"] = 0;
            existingLocations["Countertop"] = 0;
            existingLocations["Wall"] = 0;
            existingLocations["Floor"] = 0;


            var whiteTiles = new Stack<int>
                (
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                );

            var greyTiles = new Queue<int>
                (
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                );


            while (whiteTiles.Count != 0 && greyTiles.Count != 0)
            {
                int currWhiteTile = whiteTiles.Pop();
                int currGreyTile = greyTiles.Dequeue();

                if (currWhiteTile != currGreyTile)
                {
                    whiteTiles.Push(currWhiteTile / 2);
                    greyTiles.Enqueue(currGreyTile);
                    continue;
                }

                int neededArea = currWhiteTile + currGreyTile;

                if (neededArea == 40)
                {
                    existingLocations["Sink"]++;
                }
                else if (neededArea == 50)
                {
                    existingLocations["Oven"]++;
                }
                else if (neededArea == 60)
                {
                    existingLocations["Countertop"]++;
                }
                else if (neededArea == 70)
                {
                    existingLocations["Wall"]++;
                }
                else
                {
                    existingLocations["Floor"]++;
                }
            }

            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {String.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }
            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {String.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }

            foreach (KeyValuePair<string, int> location in existingLocations
                .Where(x => x.Value != 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
