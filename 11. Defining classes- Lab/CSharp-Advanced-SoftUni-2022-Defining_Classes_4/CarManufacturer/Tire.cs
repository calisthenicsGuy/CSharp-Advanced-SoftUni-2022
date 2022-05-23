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
            this.Presure = presure;
        }


        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double presure;
        public double Presure
        {
            get { return presure; }
            set { presure = value; }
        }
    }
}
