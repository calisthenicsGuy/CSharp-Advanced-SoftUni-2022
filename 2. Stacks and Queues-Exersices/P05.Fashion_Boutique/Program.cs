using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int capacityOfRack = int.Parse(Console.ReadLine());

            int counterOfNeededRack = 1;
            int sum = 0;
            while (clothes.Count != 0)
            {
                sum += clothes.Peek();
                if (sum > capacityOfRack)
                {
                    sum = 0;
                    counterOfNeededRack++;
                    continue;
                }

                clothes.Pop();
            }

            Console.WriteLine(counterOfNeededRack);
        }
    }
}
