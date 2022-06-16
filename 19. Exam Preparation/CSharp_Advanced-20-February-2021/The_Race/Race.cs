using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Race
{
    internal class Race
    {
        private List<Racer> racers;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Racers
        {
            get => this.racers;
            set => this.racers = value;
        }

        public int Count 
        { 
            get => this.Racers.Count;
        }

        public void Add(Racer Racer)
        {
            if (this.Racers.Count + 1 == this.Capacity)
            {
                return;
            }

            this.Racers.Add(Racer);
        }

        public bool Remove(string name)
        {
            Racer targetRacer = GetRacerByName(name);

            if (targetRacer == null)
            { 
                return false;
            }

            this.Racers.Remove(targetRacer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            var newList = this.Racers.OrderByDescending(a => a.Age).ToList();
            return newList[0];
        }

        public Racer GetRacer(string name)
        {
            return GetRacerByName(name);
        }

        public Racer GetFastestRacer()
        {
            var newList = this.Racers.OrderByDescending(s => s.Car.Speed).ToList();
            return newList[0];
        }

        public String Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (Racer racer in this.Racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString();
        }


        private Racer GetRacerByName(string name)
        {
            return this.Racers.FirstOrDefault(n => n.Name == name);
        }
    }
}
