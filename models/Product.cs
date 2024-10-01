namespace Westcoast_EShop.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? ItemNumber { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Product Id: {ProductId}, Name: {Name}, Price: {Price}";
    }
}
