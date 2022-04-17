using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P03.Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int query = command[0];
                if (query == 1)
                {
                    int elementToPushInStack = command[1];
                    numbers.Push(elementToPushInStack);
                }
                else if (query == 2)
                {
                    if (numbers.Count == 0)
                    {
                        continue;
                    }
                    numbers.Pop();
                }
                else if (query == 3)
                {
                    Stack<int> temp = new Stack<int>(numbers);
                    int maxNum = int.MinValue;
                    while(temp.Count >= 1)
                    {
                        if (temp.Peek() > maxNum)
                        {
                            maxNum = temp.Peek();
                        }
                        temp.Pop();
                    }

                    Console.WriteLine(maxNum);
                }
                else if (query ==  4)
                {
                    Stack<int> temp = new Stack<int>(numbers);
                    int minValue = int.MaxValue;
                    while(temp.Count >= 1)
                    {
                        if (minValue > temp.Peek())
                        {
                            minValue = temp.Peek();
                        }
                        temp.Pop();
                    }

                    Console.WriteLine(minValue);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
