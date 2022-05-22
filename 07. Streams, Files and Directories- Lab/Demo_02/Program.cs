using System;
using System.IO;

namespace Demo_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                using (StreamWriter writer = new StreamWriter(@$"output{i}.txt"))
                {
                    writer.WriteLine($"Hello from file {i}!!!");
                }
            }
        }
    }
}
