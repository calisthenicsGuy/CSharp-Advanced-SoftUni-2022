using System;
using System.IO;

namespace P02.Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\input.txt"))
            {
                string line = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    int counter = 1;
                    while (!String.IsNullOrEmpty(line))
                    {
                        writer.WriteLine($"{counter++}. {line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
