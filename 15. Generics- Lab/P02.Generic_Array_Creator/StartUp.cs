using System;

namespace P02.Generic_Array_Creator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = ArrayCreator.Create<string>(10, "null");
            int[] nums = ArrayCreator.Create<int>(10, 10);
        }
    }
}
