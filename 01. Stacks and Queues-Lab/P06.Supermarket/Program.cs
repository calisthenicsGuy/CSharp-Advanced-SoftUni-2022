using System;
using System.Collections.Generic;

namespace P06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string token;
            while ((token = Console.ReadLine()) != "End")
            {
                if (token == "Paid")
                {
                    while (customers.Count != 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(token);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
