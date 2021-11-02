using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Product
    {
       

        public  string ProductName;
        public  decimal Price;
        public  decimal? Weight;
        public  int? Quantity;
        public Pricing PricingMethod;



        public decimal GetProductAmount()
        {
            switch (PricingMethod)
            {
                case (Pricing.PerItem):
                    return (decimal)Quantity;

                case (Pricing.PerPound):
                    return (decimal)Weight;

                default:
                    return 0;
            }



        }

        public decimal GetProductPrice()
        {
            return GetProductAmount() * Price;
        }
    }
}
