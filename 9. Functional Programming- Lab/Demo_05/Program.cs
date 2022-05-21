using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // var newList = list.Select(x => x - 2);

            var newList = Select2(list, x => x - 2);
            Console.WriteLine(String.Join(" ", newList));


            //var a = list.Where(x => EvenNums(x));
            //Console.WriteLine(String.Join(" ", a));
        }

        //static bool EvenNums(int x)
        //{
        //    return x % 2 == 0;
        //}

        static List<int> Select2(List<int> collection, Func<int, int> func)
        {
            var newList = new List<int>();

            foreach (int element in collection)
            {
                newList.Add(func(element));
            }

            return newList;
        }
    }
}
