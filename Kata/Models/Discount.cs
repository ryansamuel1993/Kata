namespace Kata.Checkout
{
    public class Discount : IDiscount
    {
        public char SKU { get; set; }
		public int Quantity { get; set; }
		public double Value { get; set; }
    }
}
