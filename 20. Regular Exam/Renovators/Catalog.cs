using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get => this.renovators; set => this.renovators = value; }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count { get => this.Renovators.Count; }

        public string AddRenovator(Renovator renovator)
        {
            if (String.IsNullOrEmpty(renovator.Name) || String.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var targetRenovator = GetRenovatorByName(name);

            if (targetRenovator == null)
            {
                return false;
            }

            return this.Renovators.Remove(targetRenovator);
        }

        public int RemoveRenovatorBySpecialty(string type) => this.Renovators.RemoveAll(    x => x.Type == type);
        //{
            //var targetRenovators = GetRenovatorByTye(type);

            //if (targetRenovators == null)
            //{
            //    return 0;
            //}

            //int countOfRemovedRenovators = 0;
            //var newCollectionOfRenovators = new List<Renovator>();
            //foreach (var renovator in this.Renovators)
            //{
            //    if (!targetRenovators.Contains(renovator))
            //    {
            //        newCollectionOfRenovators.Add(renovator);
            //        continue;
            //    }
            //    countOfRemovedRenovators++;
            //}

            //this.Renovators = newCollectionOfRenovators;
            //return countOfRemovedRenovators;


            //var targetRenovators = new List<Renovator>();
            //Func<string, string, bool> predicate = (t, givenType) => t == givenType;

            //foreach (var renovator in this.Renovators)
            //{
            //    if (!predicate(renovator.Type, type))
            //    {
            //        targetRenovators.Add(renovator);
            //    }
            //}

            //int countOfRemovedRenovators = this.Count - targetRenovators.Count;
            //if (countOfRemovedRenovators == 0)
            //{
            //    return 0;
            //}

            //this.Renovators = targetRenovators;
            //return countOfRemovedRenovators;
        //}

        public Renovator HireRenovator(string name)
        {
            var targetRenovator = GetRenovatorByName(name);

            if (targetRenovator == null)
            {
                return null;
            }

            targetRenovator.Hired = true;
            return targetRenovator;
        }

        public List<Renovator> PayRenovators(int days) => this.Renovators.Where(x => x.Days >= days).ToList();
        //{
        //    var targetRenovators = new List<Renovator>();
        //    foreach (var renovator in this.Renovators)
        //    {
        //        if (renovator.Days >= days)
        //        {
        //            targetRenovators.Add(renovator);
        //        }
        //    }

        //    return targetRenovators;
        //}

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (Renovator renovator in this.Renovators)
            {
                if (renovator.Hired == false)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        private Renovator GetRenovatorByName(string name)
        {
            return this.Renovators.FirstOrDefault(x => x.Name == name);
        }
        //private List<Renovator> GetRenovatorByTye(string type)
        //{
        //    return this.Renovators.Where(x => x.Type == type).ToList();
        //}
    }
}