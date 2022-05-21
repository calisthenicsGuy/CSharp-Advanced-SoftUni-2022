using System;
using System.IO;

namespace Demo_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\exampleText.txt");
            string text = sr.ReadToEnd();
            Console.WriteLine(text);
            sr.Dispose();
            sr.Close(); // if I do not have sr.Close() data will be leaking

            // connection between file and vs

            // PowerShell
            //  ../ (step back)
            // ls
            // ref/ (step forward)

            // Relative path (..\..\..\exampleText.txt)
            // Absolute path (C:\Users\HP\source\repos\C# Advanced\CSharp-Advanced-SoftUni-Streams_Files_and_Directories\Demo_01)

            //using (StreamReader reader = new StreamReader(@"..\..\..\exampleText.txt"))
            //{
            //    string textFromFile = reader.ReadToEnd();

            //    Console.WriteLine(textFromFile);
            //}


            using (StreamReader reader = new StreamReader(@"..\..\..\exampleText.txt"))
            {
                string textFromFile = reader.ReadToEnd();

                using (StreamWriter writer = new StreamWriter(@"..\..\..\exampleWriterFile.txt"))
                {
                    writer.WriteLine($"1. {textFromFile}");
                }
            }


            // Absolute path
            Console.WriteLine(Environment.CurrentDirectory); 
        }
    }
}
