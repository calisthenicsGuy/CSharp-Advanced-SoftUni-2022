using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P9.Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Stack<string> text = new Stack<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] token = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int command = int.Parse((string)token[0]);

                if (command == 1)
                {
                    text.Push(sb.ToString());
                    sb.Append(token[1]);
                }
                else if (command == 2)
                {
                    text.Push(sb.ToString());
                    int lastCountToRemove = int.Parse(token[1]);
                    int startIndex = sb.Length - lastCountToRemove;
                    sb.Remove(startIndex, lastCountToRemove);
                }
                else if (command == 3)
                {
                    int index = int.Parse(token[1]) - 1;
                    Console.WriteLine(sb[index]);
                }
                else if (command == 4)
                {
                    sb.Clear();
                    sb.Append(text.Pop());
                }
            }
        }
    }
}
