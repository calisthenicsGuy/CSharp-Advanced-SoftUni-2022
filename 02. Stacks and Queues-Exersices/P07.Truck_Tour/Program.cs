using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> petrolStations = new Queue<int[]>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                petrolStations.Enqueue(values);
            }

            int startIndex = 0;

            while (true)
            {
                int totalLiters = 0;
                bool isCompeteCircle = true;

                foreach (int[] item in petrolStations)
                {
                    int amountOfPetrol = item[0];
                    int distance = item[1];

                    totalLiters += amountOfPetrol;
                    totalLiters -= distance;

                    if (totalLiters < 0)
                    {
                        int[] currStation = petrolStations.Dequeue();
                        petrolStations.Enqueue(currStation);
                        startIndex++;

                        isCompeteCircle = false;
                        break;
                    }
                }

                if (isCompeteCircle)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
