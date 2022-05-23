using System;
using System.IO;

namespace P01.Odd_Lines
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
                    int counterOfLines = 0;
                    while (line != null)
                    {
                        if (counterOfLines % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counterOfLines++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
