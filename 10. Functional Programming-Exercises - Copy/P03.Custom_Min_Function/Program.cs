using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> func = GetMinNumber;
            Console.WriteLine(func(numbers));
        }
        static int GetMinNumber(List<int> list)
        {
            int minNumber = int.MaxValue;

            foreach (int currNumber in list)
            {
                if (currNumber < minNumber)
                {
                    minNumber = currNumber;
                }
            }

            return minNumber;
        }
    }
}
