using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            var plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            //int newPlatesToBuild = waves / 3;
            //int[][] input = new int[waves + newPlatesToBuild][];
            //for (int i = 0; i < input.GetLength(0); i++)
            //{
            //    input[i] = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //}

            for (int i = 1; i <= waves; i++)
            {
                var orcs = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (orcs.Count != 0 && plates.Count != 0)
                {
                    int currPlate = plates.Dequeue();
                    int currOrc = orcs.Pop();

                    if (currPlate == currOrc)
                    {
                        continue;
                    }
                    else if (currOrc > currPlate)
                    {
                        currOrc -= currPlate;
                        orcs.Push(currOrc);
                    }
                    else if (currPlate > currOrc)
                    {
                        currPlate -= currOrc;
                        var items = plates.ToArray();
                        plates.Clear();
                        plates.Enqueue(currPlate);
                        foreach (int plate in items)
                        {
                            plates.Enqueue(plate);
                        }

                    }
                }

                if (plates.Count <= 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    if (orcs.Count != 0)
                        { Console.WriteLine($"Orcs left: {string.Join(", ", orcs.Where(x => x != 0))}"); }
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            if (plates.Count != 0)
                { Console.WriteLine($"Plates left: {string.Join(" ", plates.Where(x => x != 0))}"); }
        }
    }
}
