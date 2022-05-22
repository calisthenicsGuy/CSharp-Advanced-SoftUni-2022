using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Filter_By_Age
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                people.Add(new Person(name, age));
            }

            string condition = Console.ReadLine();
            int parameterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            var peopleToPrint = ReturnedPeople(people, parameterAge, condition);

            PrintingOutput(peopleToPrint, format);
        }

        static void PrintingOutput(List<Person> peopleToPrint, string format)
        {
            if (format.StartsWith("name age"))
            {
                foreach (Person person in peopleToPrint)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
            else if (format.StartsWith("name"))
            {
                foreach (Person person in peopleToPrint)
                {
                    Console.WriteLine($"{person.Name}");
                }
            }
            else if (format.StartsWith("age"))
            {
                foreach (Person person in peopleToPrint)
                {
                    Console.WriteLine($"{person.Age}");
                }
            }
        }

        static List<Person> ReturnedPeople
            (List<Person> people, int age, string condition)
        {
            if (condition == "younger")
            {
                return Where2(people, x => x.Age < age);
            }
            else if (condition == "older")
            {
                return Where2(people, x => x.Age >= age);
            }

            return null;
        }

        static List<Person> Where2(List<Person> givenList, Func<Person, bool> predicate)
        { 
            var newList = new List<Person>();

            foreach (var person in givenList)
            {
                if (predicate(person))
                {
                    newList.Add(person);
                }
            }

            return newList;
        }
    }
}
