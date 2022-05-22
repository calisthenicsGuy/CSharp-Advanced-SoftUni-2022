using System;
using System.IO;

namespace Demo_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter(@"console.txt");

            Console.SetOut(writer);

            for (int i = 1; i <= 9; i++)
            {
                Console.WriteLine(i);
            }

            writer.Dispose();

            // in PowerShell -> example: PS C:\Users\HP\source\repos\C# Advanced\CSharp-Advanced-SoftUni-Streams_Files_and_Directories\Demo_03\bin\Debug\netcoreapp3.1> .\Demo_03.exe > outFromPowerShell.txt
        }
    }
}
