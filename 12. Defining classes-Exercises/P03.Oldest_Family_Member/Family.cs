using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMembers(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            //int ageOfOldestPerson = 0;
            //Person person = null;

            //foreach (Person tempPerson in People)
            //{
            //    if (tempPerson.Age > ageOfOldestPerson)
            //    {
            //        person = tempPerson;
            //        ageOfOldestPerson = tempPerson.Age;
            //    }
            //}

            //return person;
            
            Person person = People
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return person;
        }

        public List<Person> GetPeopleThan30()
        { 
            List<Person> people = People
                .Where(x => x.Age > 30).ToList();

            return people;
        }
    }
}
