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

        public int Total()
        {
            int total = 0;
            int totalDiscount = 0;
            total = scannedItems.Sum(item => GetPrice(item));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, scannedItems));
            return total - totalDiscount;
        }

        private int GetPrice(char sku)
        {
            return products.First(p => p.SKU == sku).Price;
        }

        private int CalculateDiscount(IDiscount discount, char[] cart)
        {
            int itemCount = cart.Count(item => item == discount.SKU);
            return (itemCount / discount.Quantity) * discount.Value;
        }
    }
}