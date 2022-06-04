using System;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
            }
            ;
            
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            ;

            stack.Pop(); // Exception
        }
    }
}
