using System;
using Kata.Checkout;
using Xunit;
using System.Collections.Generic;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private ICheckout register;

        public CheckoutTests()
        {
            IEnumerable<Product> products = new[]
            {
                new Product{SKU = 'A', Price = 50},
                new Product{SKU = 'B', Price = 30},
                new Product{SKU = 'C', Price = 20},
                new Product{SKU = 'D', Price = 15}
            };

            IEnumerable<Discount> discounts = new[]
            {
                new Discount{SKU = 'B', Quantity = 3, Value = 5},
                new Discount{SKU = 'D', Quantity = 2, Value = 44}
            };

            register = new Checkout.Checkout(products, discounts);
        }

        

    }
}