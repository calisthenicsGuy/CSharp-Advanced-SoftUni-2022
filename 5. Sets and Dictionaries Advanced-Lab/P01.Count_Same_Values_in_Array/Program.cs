using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counterOfSameValue = new Dictionary<double, int>();

            double[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (!counterOfSameValue.ContainsKey(array[i]))
                {
                    counterOfSameValue[array[i]] = 1;
                    continue;
                }

                counterOfSameValue[array[i]]++;
            }

            foreach (KeyValuePair<double, int> item in counterOfSameValue)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
