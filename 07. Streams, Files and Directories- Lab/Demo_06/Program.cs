using System;
using System.IO;

namespace Demo_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[] { 83, 111, 102, 116, 33 };
            using FileStream fileStream = new FileStream(@"output.txt", FileMode.OpenOrCreate);
            fileStream.Write(buffer, 0, buffer.Length);
        }
    }
}
