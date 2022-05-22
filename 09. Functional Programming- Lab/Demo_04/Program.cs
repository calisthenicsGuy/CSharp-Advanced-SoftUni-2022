using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // var listWithEvenNumbers = list.Where(EveneNumbers);
            // Console.WriteLine(String.Join(", ", listWithEvenNumbers));

            List<int> newList = Where2(list, (int x) => { return x % 2 == 0; });
            List<int> newList2 = Where2(list, x => x % 3 == 0);
            Console.WriteLine(String.Join(", ", newList));
            Console.WriteLine(String.Join(", ", newList2));
        }

        static bool EveneNumbers(int x) => x % 2 == 0;

        static List<int> Where2(List<int> givenList, Func<int, bool> condition)
        {
            var newList = new List<int>();

            foreach (int element in givenList)
            {
                if (condition(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }
    }
}
