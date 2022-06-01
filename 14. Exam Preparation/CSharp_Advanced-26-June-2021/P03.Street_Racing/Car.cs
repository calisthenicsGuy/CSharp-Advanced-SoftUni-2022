using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Street_Racing
{
    public class Car
    {
        private string make;
        private string model;
        private string licensePlate;
        private int horsePower;
        private double weight;

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }

        public string Make 
        { get => this.make; set => this.make = value; }

        public string Model 
        { get => this.model; set => this.model = value; }

        public string LicensePlate 
        { get => this.licensePlate; set => this.licensePlate = value; }

        public int HorsePower 
        { get => this.horsePower; set => this.horsePower = value; }

        public double Weight 
        { get => this.weight; set => this.weight = value; }


        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nLicense Plate: {LicensePlate}\nHorse Power: {HorsePower}\nWeight: {Weight}";

        }
    }
}
