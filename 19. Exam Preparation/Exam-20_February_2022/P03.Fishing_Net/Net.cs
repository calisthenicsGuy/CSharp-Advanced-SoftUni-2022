using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Fishing_Net
{
    internal class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count 
        { 
            get => this.Fish.Count;
        }

        public string AddFish(Fish fish)
        {
            if (this.Count + 1 > this.Capacity)
            {
                return null;
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish targetFish = this.Fish.FirstOrDefault(fish => fish.Weight == weight);

            if (targetFish == null)
            {
                return false;
            }

            this.Fish.Remove(targetFish);
            return true;
        }

        public Fish GetFish(string fishType)
        {
            Fish targetFish = this.Fish.FirstOrDefault(fish => fish.FishType == fishType);

            if (targetFish != null)
            {
                return targetFish;
            }

            return null;
        }

        public Fish GetBiggestFish()
        {
            double length = 0;
            foreach (Fish fish in this.Fish)
            {
                if (fish.Length > length)
                {
                    length = fish.Length;
                }
            }

            Fish targetFish = this.Fish.FirstOrDefault(fish => fish.Length == length);
            return targetFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (Fish fish in this.Fish.OrderByDescending(fish => fish.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString();
        }
    }
}
