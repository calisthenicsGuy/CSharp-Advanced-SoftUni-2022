using System;

namespace CarManufacturer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car_Details car = new Car_Details("China", "Audi", 2000, 83282);

            Console.WriteLine($"The car is made in {car.Make}, the model is {car.Model}, the year of manufactured is {car.Year} and car mileage are {car.Mileage}");
        }
    }
}
