using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string direction = commandArgs[0];
                string carNumber = commandArgs[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else if (direction == "OUT")
                { 
                    carNumbers.Remove(carNumber);
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else if (carNumbers.Count != 0)
            {
                foreach (string carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
