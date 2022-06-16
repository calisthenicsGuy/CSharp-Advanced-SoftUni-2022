using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Street_Racing
{
    public class Race
    {
        private List<Car> cars = new List<Car>();
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {

            this.Name = name;
            this.Type = type;
            this.laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public string Name { get => this.name; set => this.name = value; }
        public string Type { get => this.type; set => this.type = value; }
        public int Laps { get => this.laps; set => this.laps = value; }
        public int Capacity { get => this.capacity; set => this.capacity = value; }
        public int MaxHorsePower { get => this.maxHorsePower; set => this.maxHorsePower = value; }

        public int Count()
        { 
            return cars.Count;
        }

        public void Add(Car car)
        {
            bool isHaveSameCar = false;
            foreach (Car c in cars)
            {
                if (c.LicensePlate == car.LicensePlate)
                {
                    isHaveSameCar = true;
                    break;
                }
            }

            if (!isHaveSameCar && Capacity <= cars.Count+1 && car.HorsePower <= MaxHorsePower)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            foreach (Car car in cars)
            {
                if (car.LicensePlate == licensePlate)
                {
                    cars.Remove(car);
                    return true;
                }
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (Car car in cars)
            {
                if (car.LicensePlate == licensePlate)
                {
                    return car;
                }
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            Car resultCar = null;
            int mostHorsePower = 0;
            if (cars.Count != 0)
            {
                foreach (Car car in cars)
                {
                    if (car.HorsePower > mostHorsePower)
                    {
                        mostHorsePower = car.HorsePower;
                        resultCar = car;
                    }
                }
            }

            return resultCar;
        }

        public StringBuilder Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (Car car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb;
        }
    }
}
