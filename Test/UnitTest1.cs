using System;
using Kata.Checkout;
using Xunit;
using System.Collections.Generic;

namespace Kata.Tests
{
    public class CheckoutTests
    {
        private ICheckout checkout;

        public CheckoutTests()
        {
            IEnumerable<Product> products = new[]
            {
                new Product{SKU = 'A', Price = 10},
                new Product{SKU = 'B', Price = 15},
                new Product{SKU = 'C', Price = 40},
                new Product{SKU = 'D', Price = 55}
            };

            IEnumerable<Discount> discounts = new[]
            {
                new Discount{SKU = 'B', Quantity = 3, Value = 5},
                new Discount{SKU = 'D', Quantity = 2, Value = 27.5}
            };

            checkout = new Checkout.Checkout(products, discounts);
        }

        [Fact]
        public void Empty_Basket_returns_zero()
        {
            Assert.Equal(0, checkout.Scan("").Total());
        }

        [Theory]
        [InlineData("A", 10)]
        [InlineData("B", 15)]
        [InlineData("C", 40)]
        [InlineData("D", 55)]
        public void Scan_one_of_each_item_return_correct_price(string item, double expected)
        {
            Assert.Equal(expected, checkout.Scan(item).Total());
        }

        [Theory]
        [InlineData("BBB", 40)]
        public void Scan_three_b_expect_discounted_price(string item, double expected)
        {
            Assert.Equal(expected, checkout.Scan(item).Total());
        }

        [Theory]
        [InlineData("DD", 82.5)]
        public void Scan_two_d_expect_discounted_price(string item, double expected)
        {
            Assert.Equal(expected, checkout.Scan(item).Total());
        }

        [Theory]
        [InlineData("DDD", 137.5)]
        public void Scan_three_d_expect_discounted_price_only_on_first_two(string item, double expected)
        {
            Assert.Equal(expected, checkout.Scan(item).Total());
        }

    }
}