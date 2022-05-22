using System;
using System.Collections.Generic;

namespace P01.Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var uniqueName = new HashSet<string>();

            for (int i = 1; i <= n; i++)
            {
                uniqueName.Add(Console.ReadLine());
            }

            foreach (string name in uniqueName)
            {
                Console.WriteLine(name);
            }
        }
    }
}
