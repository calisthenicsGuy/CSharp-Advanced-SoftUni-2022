
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car_Details
    {
        public Car_Details(string make, string model, int year, int mileage)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Mileage = mileage;
        }

        private string make;
        public string Make 
        {
            get 
            { 
                return make;
            }

            set
            { 
                make = value;
            }
        }


        private string model;
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }


        private int year;
        public int Year 
        { 
            get
            {
                return year;
            }
            set
            {
                if (value < 2002)
                {
                    Console.WriteLine($"The car is too old! It's dangerous for travel!!!");
                }
                else
                {
                    year = value;
                }
            }
        }


        private int mileage;
        public int Mileage 
        {
            get
            { 
                return mileage;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Something wrong in data of mileage!!!");
                }
                else if (value >= 10000)
                {
                    Console.WriteLine($"The car mileage is {value}.");
                    Console.WriteLine("This is too much kilometers! The car is dangerous dor travel!!!");
                }
            }
        }
    }
}
