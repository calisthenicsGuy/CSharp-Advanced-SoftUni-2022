using System;

namespace P00.Enumerations_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            DayOfWeek day = new DayOfWeek();
            Console.WriteLine(day.Day); // return: Monday
            Console.WriteLine((int)day.Day); // return: 1

            Console.WriteLine();

            day.Day = Days.Tuesday;
            Console.WriteLine(day.Day); // return: Tuesday
            Console.WriteLine((int)day.Day); // return: 2

            Console.WriteLine();

            Days day1 = Days.Wednesday;
            Console.WriteLine(day1); // return: Wednesday
            Console.WriteLine((int)day1); // return: 3

            Console.WriteLine();

            day1 = (Days)4;
            Console.WriteLine(day1); // return: Thursday
            Console.WriteLine((int)day1); // return: 4

            Console.WriteLine((Days)100); // return: Saturday, because I set value of the Saturday- 100
        }
    }
}
