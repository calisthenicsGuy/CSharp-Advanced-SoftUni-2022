using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.Custom_Comparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, bool> func = num => num % 2 == 0;
            int[] evenNumbers = FindEvenOrOddNums(func, numbers);
            Array.Sort(evenNumbers);

            func = num => num % 2 != 0;
            int[] oddNumbers = FindEvenOrOddNums(func, numbers);
            Array.Sort(oddNumbers);

            numbers = ReturnFinalArray(evenNumbers, oddNumbers).ToArray();
            Console.WriteLine(String.Join(" ", numbers));
        }

        static int[] FindEvenOrOddNums(Func<int, bool> predicate, int[] array)
        { 
            var newList = new List<int>();

            foreach (int num in array)
            {
                if (predicate(num))
                {
                    newList.Add(num);
                }
            }

            return newList.ToArray();
        }

        static int[] ReturnFinalArray(int[] arr1, int[] arr2)
        {
            var newList = new List<int>();
            foreach (int num in arr1)
            {
                newList.Add(num);
            }
            foreach (int num in arr2)
            {
                newList.Add(num);
            }

            return newList.ToArray();
        }
    }
}
