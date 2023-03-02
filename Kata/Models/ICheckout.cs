using System;

namespace Kata.Checkout
{
    public interface ICheckout
    {
        ICheckout Scan(String scan);
        int Total();
        char[] ScannedProducts { get; }
    }
}
