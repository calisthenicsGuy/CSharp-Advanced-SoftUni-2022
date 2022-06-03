using System;

namespace P03.Generic_Scale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var scale1 = new EqualityScale<int>(16, 25);
            Console.WriteLine(scale1.AreEqual());


            var scale2 = new EqualityScale<int>(36, 36);
            Console.WriteLine(scale2.AreEqual());
        }
    }
}
