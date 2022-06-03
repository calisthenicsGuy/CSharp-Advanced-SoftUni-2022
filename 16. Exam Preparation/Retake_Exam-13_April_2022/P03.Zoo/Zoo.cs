using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Zoo
{
    internal class Zoo
    {

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public string AddAnimal(Animal animal)
        {
            if (String.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (this.Capacity < this.Animals.Count + 1)
            {
                return "The zoo is full.";
            }

            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            List<Animal> removedAnimal = this.Animals.Where(s => s.Species == species).ToList();
            List<Animal> newList = new List<Animal>();

            foreach (var animal in this.Animals)
            {
                if (!removedAnimal.Contains(animal))
                {
                    newList.Add(animal);
                }
            }
            this.Animals = newList;

            return removedAnimal.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> targetAnimals = this.Animals.Where(d => d.Diet == diet).ToList();

            return targetAnimals;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal targetAnimal = this.Animals.FirstOrDefault(w => w.Weight == weight);

            return targetAnimal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> targetAnimals = 
                this.Animals.Where(l => l.Length >= minimumLength && l.Length <= maximumLength).ToList();

            return 
                $"There are {targetAnimals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
