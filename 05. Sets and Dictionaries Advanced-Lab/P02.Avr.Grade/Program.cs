using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Avr.Grade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }

                students[name].Add(grade);
            }

            foreach (KeyValuePair<string, List<decimal>> student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (double grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }

            //foreach (KeyValuePair<string, List<double>> student in students)
            //{
            //    Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value)} (avg: {student.Value.Average():f2})");
            //}
        }
    }
}
