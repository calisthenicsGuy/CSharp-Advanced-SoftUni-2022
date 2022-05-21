using System;

namespace Demo_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, long> func = Multply;
            Console.WriteLine(func(3, 5));

            Func<int, int, int, int, long> func1 = MathOperation;
            Console.WriteLine(func1(3, 5, 7, 2));
        }

        public static long Multply(int a, int b)
        {
            return a * b;
        }

        public static long MathOperation(int a, int b, int c, int d)
        {
            return ((a * b) + (a * c)) / d;
        }
    }
}
