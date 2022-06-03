using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array1 = CreateArray<int>(10, 3);
            var array2 = CreateArray<string>(10, "Rado");
            
            var list1 = CreateList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10} );

            list1 = FindElementsThatAreBiggerOrEqualToCountOfTheirCollection((x, y) => x >= y, list1).ToList();
            ;
        }

        public static T[] CreateArray<T>(int count, T element)
        {
            var array = new T[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = element;
            }
            return array;
        }

        public static List<T> CreateList<T>(List<T> elements)
        {
            var list = elements;
            return list;
        }


        public static List<T> FindElementsThatAreBiggerOrEqualToCountOfTheirCollection<T>
            (Func<T, int, bool> predicate, List<T> list)
        {
            var newList = new List<T>();

            foreach (var item in list)
            {
                if (predicate(item, list.Count))
                {
                    newList.Add(item);
                }
            }

            return newList;
        }
    }
}
