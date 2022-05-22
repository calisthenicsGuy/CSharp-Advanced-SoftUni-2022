using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Product_Shop
{
    public class ShopItem
    {
        public ShopItem(string product, double price)
        {
            this.Product = product;
            this.Price = price;
        }
        public string Product { get; set; }
        public double Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<ShopItem>> shops = new Dictionary<string, List<ShopItem>>();

            string command;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] commandArgs = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string shop = commandArgs[0];
                string product = commandArgs[1];
                double price = double.Parse(commandArgs[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new List<ShopItem>();
                }

                ShopItem shopItem = new ShopItem(product, price);
                shops[shop].Add(shopItem);
            }

            foreach (KeyValuePair<string, List<ShopItem>> shop in shops.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Product}, Price: {product.Price}");
                }
            }
        }
    }
}
