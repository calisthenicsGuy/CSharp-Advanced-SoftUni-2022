using System;
using System.Collections.Generic;
using System.Linq;
using CarManufacture;

namespace P07.Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tires[] tires = new Tires[4]
                {
                    new Tires(tire1Age, tire1Pressure),
                    new Tires(tire2Age, tire2Pressure),
                    new Tires(tire3Age, tire3Pressure),
                    new Tires(tire4Age, tire4Pressure)
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> carsOutput = new List<Car>();

            if (command == "fragile")
            {
                carsOutput = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1))
                    .ToList();
            }
            else if (command == "flammable")
            {
                carsOutput = cars
                    .Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250)
                    .ToList();
            }

            foreach (Car car in carsOutput)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
