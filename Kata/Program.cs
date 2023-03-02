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
             
        }

        public int GetTotal()
        {
            int total = 0;
            int totalDiscount = 0;
            
        }

       
    }
}