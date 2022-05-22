using System;
using System.Collections.Generic;

namespace P04_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            FillingDictionary(numbers, n);

            foreach (KeyValuePair<int, int> num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }

            }
        }

        private static Dictionary<int, int> FillingDictionary(Dictionary<int, int> numbers, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, 0);
                }
                numbers[currentNumber]++;
            }
            return numbers;
        }
    }
}
