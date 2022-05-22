using System;
using System.IO;

namespace Demo_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter(@"output.txt");
            writer.WriteLine("123");
            writer.Dispose();

            using FileStream fileStream = new FileStream(@"output.txt", FileMode.OpenOrCreate);
            byte[] buffer = new byte[1024];
            fileStream.Read(buffer, 0, 10);
        }
    }
}
