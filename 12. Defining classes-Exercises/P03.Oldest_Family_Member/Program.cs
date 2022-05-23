using System;
using System.Collections.Generic;
using System.Linq;
using DefiningClasses;

namespace P03.Oldest_Family_Member_And_P04
{
    public class Program
    {
        static void Main(string[] args)
        {

            // P03.Oldest_Family_Member
            /*Family family = new Family();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] personInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personInput[0];
                int age = int.Parse(personInput[1]);

                Person newPerson = new Person(name, age);
                family.AddMembers(newPerson);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}")*/


            //P04.Opinion_Poll
            DefiningClasses.Family family = new Family();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1  ; i <= n; i++)
            {
                string[] personInformation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personInformation[0];
                int age = int.Parse(personInformation[1]);

                Person person = new Person(name, age);
                family.AddMembers(person);
            }

            List<Person> people = family.GetPeopleThan30();

            foreach (Person person in people.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
