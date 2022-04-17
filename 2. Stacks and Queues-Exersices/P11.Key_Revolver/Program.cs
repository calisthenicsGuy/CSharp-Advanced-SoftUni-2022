using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfSingleBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int tempSizeOfGunBarrel = sizeOfGunBarrel;
            Stack<int> bullets = new Stack<int>
                (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> locks = new Queue<int>
                (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            int countOfNeededBullets = 0;
            while (locks.Count != 0)
            {
                countOfNeededBullets++;
                int currentBullet = bullets.Pop();
                if (currentBullet <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else if (currentBullet > locks.Peek())
                {
                    Console.WriteLine("Ping!");
                }

                if (bullets.Count == 0 && locks.Count != 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    Environment.Exit(0);
                }

                tempSizeOfGunBarrel--;
                if (tempSizeOfGunBarrel == 0 && bullets.Count != 0)
                {
                    tempSizeOfGunBarrel = sizeOfGunBarrel;
                    Console.WriteLine("Reloading!");
                }
            }

            Console.WriteLine($"{bullets.Count} bullets left. Earned " +
                $"${valueOfIntelligence - countOfNeededBullets * priceOfSingleBullet}");
        }
    }
}
