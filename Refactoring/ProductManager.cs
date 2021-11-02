using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class ProductManager
    {
        private string OrderSummary;
        private decimal totalPrice;

        public decimal TotalPrice => totalPrice;

        public ProductManager()
        {
            OrderSummary = String.Empty;
            totalPrice = 0m;
        }

        public string CalculateTotalPrice(List<Product> Products)
        {

            foreach (var orderProduct in Products)
            {

                OrderSummary += orderProduct.ProductName;
                var amount = orderProduct.GetProductAmount();
                var productPrice = orderProduct.GetProductPrice();

                totalPrice += productPrice;

                switch (orderProduct.PricingMethod)
                {
                    case (Data.Pricing.PerItem):
                        OrderSummary += (" $" + productPrice + " (" + amount + " items at $" + orderProduct.Price + " each)");
                        break;

                    case (Data.Pricing.PerPound):
                        OrderSummary += (" $" + productPrice + " (" + amount + " pounds at $" + orderProduct.Price + " per pound)");
                        break;

                }

                OrderSummary += "\r\n";
            }


            return OrderSummary;
        }
    }
}
