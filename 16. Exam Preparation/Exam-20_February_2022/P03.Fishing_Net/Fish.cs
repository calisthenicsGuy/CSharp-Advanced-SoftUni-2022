using System;

namespace P03.Fishing_Net
{
    internal class Fish
    {
        private string fishType;
        private double length;
        private double weight;


        public Fish(string fisthType, double length, double weight)
        {
            this.FishType = fisthType;
            this.Length = length;
            this.Weight = weight;
        }


        public string FishType 
        {
            get => this.fishType;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Inavlid fish.");
                }

                this.fishType = value;
            }
        }

        public double Length 
        {
            get => this.length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Inavlid fish.");
                }

                this.length = value;
            }
        }

        public double Weight 
        {
            get => this.weight; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Inavlid fish.");
                }

                this.weight = value;
            }
        }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
