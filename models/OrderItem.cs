namespace Westcoast_EShop.Models;

public class OrderItem
{
    public int Quantity { get; set; }
    public decimal LineSum { get; set; }
    public decimal Discount { get; set; }

    public Product? Product { get; set; }

    public override string ToString()
    {
        return $"Quantity: {Quantity}, LineSum: {LineSum}, Discount: {Discount}, Product: {Product}";
    }
}
