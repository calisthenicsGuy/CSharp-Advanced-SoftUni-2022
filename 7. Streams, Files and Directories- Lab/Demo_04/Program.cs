using System;
using System.IO;
using System.Text;

namespace Demo_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer1 = new StreamWriter(@"encodingExampleWithASCII.txt", false, Encoding.ASCII);

            writer1.WriteLine("123");
            writer1.Dispose();

            StreamWriter writer2 = new StreamWriter(@"encodingExampleWithUnicode.txt", false, Encoding.Unicode);

            writer2.WriteLine("123");
            writer2.Dispose();
        }
    }
}
