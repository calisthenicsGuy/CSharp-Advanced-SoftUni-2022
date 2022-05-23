using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Tire[]> allTires = new List<Tire[]>();
            while (input != "No more tires")
            {
                int counter = 0;
                Tire[] currTires = new Tire[4];
                string[] tiresInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    currTires[counter] = tire;
                    counter++;
                }

                allTires.Add(currTires);

                input = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            string input2 = Console.ReadLine();
            while (input2 != "Engines done")
            {
                string[] engineInfo = input2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input2 = Console.ReadLine();
            }

            List<Car> allCars = new List<Car>();
            string input3 = Console.ReadLine();
            while (input3 != "Show special")
            {
                string[] carInfo = input3.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], allTires[tiresIndex]);
                allCars.Add(car);

                input3 = Console.ReadLine();
            }

            List<Car> specialCars = allCars
                .Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330)
                .ToList();

            foreach (Car car in specialCars)
            {
                double tirePressureSum = 0;
                foreach (var tire in car.Tire)
                {
                    tirePressureSum += tire.Pressure;
                }
                if (tirePressureSum > 9 && tirePressureSum < 10)
                {
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");

                    car.FuelQuantity = car.FuelQuantity - (car.FuelConsumption / 100 * 20);

                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
