using System;
using System.Collections.Generic;

namespace P08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int numberOfCarsThatCanPassDuringAGreenLight = 
                    int.Parse(Console.ReadLine());

            int countOfPassedCars = 0;
            string token;
            while((token = Console.ReadLine()) != "end")
            {
                if (token == "green")
                {
                    for (int i = 1; i <= numberOfCarsThatCanPassDuringAGreenLight; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countOfPassedCars++;
                    }
                }
                else
                {
                    cars.Enqueue(token);
                }
            }

            Console.WriteLine($"{countOfPassedCars} cars passed the crossroads.");
        }
    }
}
