using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            Queue<int> customersOrders = new Queue<int>
                (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Console.WriteLine(customersOrders.Max());
            while (customersOrders.Count != 0)
            {
                if (quantityOfFood >= customersOrders.Peek())
                {
                    quantityOfFood -= customersOrders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", customersOrders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
