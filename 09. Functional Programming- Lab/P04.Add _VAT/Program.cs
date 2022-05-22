using System;
using System.Linq;

namespace P04.Add__VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => (x + (x * 0.20)))
                .ToList();

            Console.WriteLine(String.Join("\n", prices.Select(x => $"{x:f2}")));
        }
    }
}
