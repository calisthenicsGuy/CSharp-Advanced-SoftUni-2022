using System;
using System.Collections.Generic;

namespace P8.SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string receivedGuest;
            while ((receivedGuest = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(receivedGuest[0]))
                {
                    vipGuests.Add(receivedGuest);
                }
                else
                {
                    regularGuests.Add(receivedGuest);
                }
            }

            receivedGuest = null;
            while ((receivedGuest = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(receivedGuest[0]))
                {
                    vipGuests.Remove(receivedGuest);
                }
                else
                {
                    regularGuests.Remove(receivedGuest);
                }
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            foreach (string vipGuest in vipGuests)
            {
                Console.WriteLine(vipGuest);
            }
            foreach (string regularrGuest in regularGuests)
            {
                Console.WriteLine(regularrGuest);
            }
        }
    }
}
