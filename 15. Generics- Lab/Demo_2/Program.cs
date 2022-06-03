using System;
using System.Collections.Generic;

namespace Demo_2
{
    class Pair<T>
    {
        public Pair()
        {

        }

        public T FirstElement { get; set; }
        public T SecondElement { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var pair1 = new Pair<int>();
            Console.WriteLine(pair1.FirstElement.GetType()); // System.Int32
            Console.WriteLine(pair1.SecondElement.GetType()); // System.Int32

            var pair2 = new Pair<string>();
            pair2.FirstElement = "null";
            pair2.FirstElement = "null";
            Console.WriteLine(pair2.FirstElement.GetType()); // System.String
            Console.WriteLine(pair2.SecondElement.GetType()); // System.String

            var pair3 = new Pair<List<int>>();
            pair3.FirstElement = new List<int>() { 1, 2, 3 };
            pair3.SecondElement = new List<int>() { 4, 5, 6 };
            Console.WriteLine(pair3.FirstElement.GetType());
            Console.WriteLine(pair3.SecondElement.GetType());
        }
    }
}
