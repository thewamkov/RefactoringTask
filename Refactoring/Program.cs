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
                        PricingMethod = "PerPound",
                    },
                    new Product
                    {
                        ProductName = "Coke",
                        Price = 3m,
                        Quantity = 2,
                        PricingMethod = "PerItem"
                    }
                }
            );

            var price = 0m;
            var orderSummary = "ORDER SUMMARY FOR " + order.Item1 + ": \r\n";

            foreach (var orderProduct in order.Item2)
            {
                
                orderSummary += orderProduct.ProductName;
                var amount = getProductAmount(orderProduct);


                var productPrice = (amount * orderProduct.Price);
                price += productPrice;


                if (orderProduct.PricingMethod == "PerPound")
                    orderSummary += (" $" + productPrice + " (" + amount + " pounds at $" + orderProduct.Price + " per pound)");

                else // Per item
                    orderSummary += (" $" + productPrice + " (" + amount + " items at $" + orderProduct.Price + " each)");



                orderSummary += "\r\n";
            }

            Console.WriteLine(orderSummary);
            Console.WriteLine("Total Price: $" + price);

            Console.ReadKey();
        }

        public static decimal getProductAmount(Product product)
        {
            
            return product.Weight != null ? product.Weight.Value : product.Quantity.Value; 

        }

        
    }

    public class Product
    {
        public string ProductName;
        public decimal Price;
        public decimal? Weight;
        public int? Quantity;
        public string PricingMethod;
    }
}

