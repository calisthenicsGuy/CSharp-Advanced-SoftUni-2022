using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public List<Drone> Drones
        {
            get => this.drones;
            set => this.drones = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }
        public double LandingStrip 
        { 
            get => this.landingStrip; 
            set => this.landingStrip = value; 
        }

        public int Count 
        {
            get => this.Drones.Count;
        }

        public string AddDrone(Drone drone)
        {
            if (this.Count + 1 > this.Capacity)
            {
                return "Airfield is full.";
            }
            if ((drone.Range < 5 || drone.Range > 15) || 
                (string.IsNullOrEmpty(drone.Brand)) || 
                (string.IsNullOrEmpty(drone.Name)))
            {
                return "Invalid drone.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone targetDrone = GetTargetDrone(name);

            if (targetDrone == null)
            {
                return false;
            }

            this.Drones.Remove(targetDrone);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int removedDrones = 0;
            Func<string, string, bool> predicate = (x, b) => x != b;
            this.Drones = GetDronesByBrand(brand, predicate, ref removedDrones).ToList();
            
            return removedDrones;
        }

        private List<Drone> GetDronesByBrand(string brand, Func<string, string, bool> predicate, ref int removedDrones)
        {
            var newList = new List<Drone>();

            foreach (var drone in this.Drones)
            {
                if (predicate(drone.Brand, brand))
                {
                    newList.Add(drone);
                    continue;
                }
                removedDrones++;
            }

            return newList;
        }

        public Drone FlyDrone(string name)
        {
            Drone targetDrone = GetTargetDrone(name);

            if (targetDrone != null)
            {
                targetDrone.Available = false;
                return targetDrone;
            }

            return null;
            // return targetDrone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            Func<int, int, bool> predicate = (x, r) => x >= r;
            var targetDrones = GetDronesByRange(range, predicate).ToList();

            return targetDrones;
        }

        private List<Drone> GetDronesByRange(int range, Func<int, int, bool> predicate)
        {
            var newList = new List<Drone>();

            foreach (var drone in this.Drones)
            {
                if (predicate(drone.Range, range))
                {
                    newList.Add(drone);
                    drone.Available = false;
                }
            }

            return newList;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var drone in this.Drones)
            {
                if (drone.Available)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString();
        }

        private Drone GetTargetDrone(string name)
        {
            return this.Drones.FirstOrDefault(n => n.Name == name);
        }
    }
}
