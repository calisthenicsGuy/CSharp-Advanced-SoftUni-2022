using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P07.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<string> children = new Queue<string>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            int number = int.Parse(Console.ReadLine());

            while (children.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }

            Console.WriteLine($"Last is {children.Peek()}");
        }
    }
}
