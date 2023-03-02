using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout
{
    public class Checkout : ICheckout
    {
        private readonly IEnumerable<IProduct> products;
        private readonly IEnumerable<IDiscount> discounts;

        private char[] scannedItems;
        public char[] ScannedItems { get { return scannedItems; } }

        public Checkout(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts)
        {
            this.products = products;
            this.discounts = discounts;
            scannedItems = new char[] { };
        }

        public ICheckout Scan(String scan)
        {
            if (!String.IsNullOrEmpty(scan))
            {
                scannedItems =
                    scan.ToCharArray()
                         .Where(scannedSKU => products.Any(product => product.SKU == scannedSKU))
                         .ToArray();
            }
            return this;
        }

        public double Total()
        {
            double total = 0;
            double totalDiscount = 0;
            total = scannedItems.Sum(item => GetPrice(item));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, scannedItems));
            return total - totalDiscount;
        }

        private double GetPrice(char sku)
        {
            return products.First(p => p.SKU == sku).Price;
        }

        private double CalculateDiscount(IDiscount discount, char[] basket)
        {
            int itemCount = basket.Count(item => item == discount.SKU);
            double t = (itemCount / discount.Quantity) * discount.Value;
            return t;
        }
    }
}