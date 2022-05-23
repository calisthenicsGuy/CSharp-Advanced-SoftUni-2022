using System;

namespace P00.Static_Classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            double areaOfSquare = MathOperations.CalculateAreaOfSquare(5.2);
            Console.WriteLine($"{areaOfSquare:f2}");

            double areaOfTriangle = MathOperations.CalculateAreaOfTriangle(2, 5.6);
            Console.WriteLine($"{areaOfTriangle:f2}");

            double areaOfCircle = MathOperations.CalculateAreaOfCircle(3.5);
            Console.WriteLine($"{areaOfCircle:f2}");


            MathOperations math = new MathOperations();
            // ! - math.CalculateAreaOfSquare(4); - ! - this is wrong, because static classes and static methods cannot be instantiated

        }
    }
}
