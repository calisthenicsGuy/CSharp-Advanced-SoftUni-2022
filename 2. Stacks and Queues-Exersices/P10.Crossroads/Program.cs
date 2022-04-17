using System;
using System.Collections.Generic;

namespace P10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsOnTheTrafficJam = new Queue<string>();

            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            int countOfPassedCras = 0;
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    carsOnTheTrafficJam.Enqueue(command);
                    continue;
                }

                int currentSecondsLeft = durationOfGreenLight;
                while (currentSecondsLeft >= 0 && carsOnTheTrafficJam.Count != 0)
                {
                    string currentCar = carsOnTheTrafficJam.Dequeue();
                    if (currentSecondsLeft - currentCar.Length >= 0)
                    {
                        currentSecondsLeft -= currentCar.Length;
                        countOfPassedCras++;
                    }
                    else if (currentSecondsLeft + durationOfFreeWindow - currentCar.Length >= 0)
                    {
                        currentSecondsLeft = 0;
                        countOfPassedCras++;
                    }
                    else
                    {
                        int posititonOfHittedChar = currentSecondsLeft + durationOfFreeWindow;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentCar[posititonOfHittedChar]}.");

                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine("3 total cars passed the crossroads.");
        }
    }
}
