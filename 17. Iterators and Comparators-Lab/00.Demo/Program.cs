using System;
using System.Collections.Generic;

namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "Hello", "World", "Of", "C#" };

            IEnumerator<string> ewords = words.GetEnumerator();

            while (ewords.MoveNext())
            {
                Console.WriteLine(ewords.Current);
                // ewords.Reset(); endless loop
            }

            Console.WriteLine();

            PrintNames("Rado", "Ivcho", "Gosho");
            PrintNames("Radko", "Goshko");
            PrintNumbers(5, 6, 7);
            PrintNumbers(8);
        }

        public static void PrintNames(params string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        public static void PrintNumbers(params int[] nums)
        {
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
        }
    }
}
