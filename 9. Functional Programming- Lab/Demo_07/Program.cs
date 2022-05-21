using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_07
{
    delegate bool Predicate(int a, int b); // Func<int, int. bool>

    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate result = Result; // Predicate result = (x, y) => x % y == 0;
            Console.WriteLine(result(12, 3));
            Console.WriteLine(result(3, 4));
        }

        static bool Result(int x, int y)
        {
            return x % y == 0;
        }
    }
}
