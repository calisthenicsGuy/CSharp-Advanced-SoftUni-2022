using System;
using DefiningClasses;

namespace P01.Define_a_Class_Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DefiningClasses.Person person1 = new DefiningClasses.Person("Peter", 20);
            DefiningClasses.Person person2 = new DefiningClasses.Person("George", 18);
            DefiningClasses.Person person3 = new DefiningClasses.Person("Sam", 43);
        }
    }
}
