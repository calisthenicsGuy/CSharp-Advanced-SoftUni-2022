using System;

namespace Demo_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, long> func = Multiply;
            // Result(1, 1, func);
            Result(1, 1, Add, Multiply);
        }

        static void Result
            (int a, int b, Func<Func<int, int, long>, int, int, long> func, Func<int, int, long> subFunc)
        {
            for (int i = 1; i <= 5; i++)
            {
                var result = func(subFunc, a + i, b + i);

                Console.WriteLine(result);
                Console.WriteLine(new String('=', 50));
            }
        }

        static long Multiply(int a, int b)
        {
            return a * b;
        }

        static long Add(Func<int, int, long> func, int a, int b)
        {
            return func(a, b) + b;
        }
    }
}
