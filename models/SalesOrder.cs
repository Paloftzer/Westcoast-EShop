namespace Westcoast_EShop.Models;

public class SalesOrder
{
    public string OrderId { get; set; } = "";
    public DateTime OrderDate { get; set; }

    public Customer? Customer { get; set; }

    public override string ToString()
    {
        return $"Order Id: {OrderId}, Customer: {Customer}";
    }
}