using System;

namespace Kata.Checkout
{
    public interface ICheckout
    {
        ICheckout Scan(String scan);
        double Total();
        char[] ScannedItems { get; }
    }
}
