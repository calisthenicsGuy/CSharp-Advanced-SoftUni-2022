using System;
using System.Linq;

namespace P05.Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {

                switch (command)
                {
                    case "add": 
                        numbers = numbers
                            .Select(x => x += 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers
                            .Select(x => x *= 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers
                            .Select(x => x -= 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                    default:
                        return;
                        break;
                }
            }
        }
    }
}