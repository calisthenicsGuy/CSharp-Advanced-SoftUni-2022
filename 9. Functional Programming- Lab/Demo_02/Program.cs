using System;

namespace Demo_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, long> func1 = Substract;
            Func<int, int, long> func2 = Add;
            Func<int, int, long> func3 = Multiply;
            // Result(1, 1, func2);
            Result(1, 1, Add);
            Result2(1, 1, func3, func2);

        }

        static void Result(int a, int b, Func<int, int, long> func)
        {
            for (int i = 1; i <= 10; i++)
            {
                long result = func(a + i, b + i);
                Console.WriteLine($"Result: {result}");
                Console.WriteLine(new string('=', 50));
            }

        }

        static void Result2(int a, int b, Func<int, int, long> func1, Func<int, int, long> func2)
        {
            for (int i = 1; i <= 5; i++)
            {
                var result = func1(a + i, b + i) * func2(a + i, b + i);
                Console.WriteLine(result);
                Console.WriteLine(new string('=', 50));
            }
        }


        static long Substract(int a, int b)
        {
            return a - b;
        }

        static long Add(int a, int b)
        {
            return a + b;
        }

        static long Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
