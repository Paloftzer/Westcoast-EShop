namespace Westcoast_EShop.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastPurchase { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? AddressLine { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public override string ToString()
    {
        return $"Customer Id: {CustomerId}, Account Creation Date: {CreationDate}, Last Purchase Date: {LastPurchase}, Name: {FirstName} {LastName}, Address: {AddressLine}, Postal Code: {PostalCode}, City: {City}";
    }
}
