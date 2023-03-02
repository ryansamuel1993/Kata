namespace Kata.Checkout
{
    public interface IDiscount
    {
        char SKU { get; set; }
		int Quantity { get; set; }
        double Value { get; set; }
    }
}
