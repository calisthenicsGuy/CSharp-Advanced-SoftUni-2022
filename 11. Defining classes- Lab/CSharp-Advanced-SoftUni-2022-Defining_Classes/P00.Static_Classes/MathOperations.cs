using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P00.Static_Classes
{
    public class MathOperations
    {
        public static double CalculateAreaOfSquare(double a)
        {
            return a * a;
        }

        public static double CalculateAreaOfTriangle(double a, double b)
        {
            return ((a * b) / 2);
        }

        private static double pi = 3.14;
        public static double CalculateAreaOfCircle(double r)
        { 
            return (MathOperations.pi * (r * r));
        }
    }
}
