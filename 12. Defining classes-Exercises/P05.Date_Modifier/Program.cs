using System;

namespace P05.Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.CalculateDifference(firstDate, secondDate));
        }
    }
}
