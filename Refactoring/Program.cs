using System;
using System.Collections.Generic;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Tuple<string, List<Product>>("John Doe",
                new List<Product>
                {
                    new Product
                    {
                        ProductName = "Pulled Pork",
                        Price = 6.99m,
                        Weight = 0.5m,
                        PricingMethod = Data.Pricing.PerPound,
                    },
                    new Product
                    {
                        ProductName = "Coke",
                        Price = 3m,
                        Quantity = 2,
                        PricingMethod = Data.Pricing.PerItem
                    }
                }
            );
            var productManager = new ProductManager();
            var orderSummary = "ORDER SUMMARY FOR " + order.Item1 + ": \r\n" + productManager.CalculateTotalPrice(order.Item2);




            //orderSummary += productManager.CalculateTotalPrice(order.Item2);

            Console.WriteLine(orderSummary);
            Console.WriteLine("Total Price: $" + productManager.TotalPrice);

            Console.ReadKey();
        }




    }


}

