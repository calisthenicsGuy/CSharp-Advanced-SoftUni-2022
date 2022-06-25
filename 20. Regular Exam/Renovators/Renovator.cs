using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
            this.Hired = false;
        }

        public string Name { get => this.name; set => this.name = value; }
        public string Type { get => this.type; set => this.type = value; }
        public double Rate { get => this.rate; set => this.rate = value; }
        public int Days { get => this.days; set => this.days = value; }
        public bool Hired { get => this.hired; set => this.hired = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {this.Name}");
            sb.AppendLine($"--Specialty: {this.Type}");
            sb.AppendLine($"--Rate per day {this.Rate} BGN");

            return sb.ToString().Trim();
        }
    }
}
