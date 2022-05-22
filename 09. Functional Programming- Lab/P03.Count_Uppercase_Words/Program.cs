using System;
using System.Linq;

namespace P03.Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            words = words.Where(FindUppercaseWprd).ToList();

            Console.WriteLine(String.Join("\n", words));
        }

        static bool FindUppercaseWprd(string x) => char.IsUpper(x[0]);
    }
}