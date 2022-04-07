using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseText = new Stack<char>(input);
            
            Console.WriteLine(string.Join("", reverseText));


            //char[] symbols = Console.ReadLine()
            //    .ToCharArray();

            //Stack<char> myStack = new Stack<char>();
            //foreach (var item in symbols)
            //{
            //    myStack.Push(item);
            //}

            //Console.WriteLine(string.Join("", myStack));



            //char[] symbols = Console.ReadLine()
            //    .ToCharArray();
            //Array.Reverse<char>(symbols);
            //Console.WriteLine(new string(symbols));
        }
    }
}
