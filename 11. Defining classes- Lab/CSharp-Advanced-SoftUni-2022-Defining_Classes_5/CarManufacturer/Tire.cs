using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year, double presure)
        {
            this.Year = year;
            this.Pressure = presure;
        }


        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double pressure;
        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}
