using System;

namespace Demo_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int, int> action = ActionMultiplyMethod;
            action(2, 4);
        }
        static void ActionMultiplyMethod(int a, int b)
        {
            Console.WriteLine(a * b);
        }
    }
}
