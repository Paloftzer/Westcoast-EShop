using System.Text.Encodings.Web;
using System.Text.Json;
using Westcoast_EShop.Models;

namespace Westcoast_EShop;

class Program
{
    private static readonly JsonSerializerOptions s_writeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    private static readonly JsonSerializerOptions s_readOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    static void Main()
    {
        SalesOrder order = new()
        {
            OrderId = "123456789",
            OrderDate = DateTime.Now,
            Customer = new Customer
            {
                CustomerId = 123456789,
                CreationDate = DateTime.Now,
                LastPurchase = DateTime.Now,
                FirstName = "John",
                LastName = "Doe",
                AddressLine = "1st Street",
                PostalCode = "55 588",
                City = "London"
            }
        };

        var orderItem = new OrderItem()
        {
            Quantity = 40,
            Discount = 0.10m
        };
        var product = new Product()
        {
            ProductId = 1,
            ItemNumber = "1-00001",
            Name = "First Product",
            Price = 1000
        };
        orderItem.Product = product;
        orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

        order.OrderItems = [];
        order.OrderItems.Add(orderItem);

        var path = string.Concat(Environment.CurrentDirectory, "/data/salesorder.json");
        var json = JsonSerializer.Serialize(order, s_writeOptions);

        File.WriteAllText(path, json);

        Console.WriteLine(File.ReadAllText(path));

        var salesorder = JsonSerializer.Deserialize<SalesOrder>(json, s_readOptions);
        Console.WriteLine(salesorder);
    }
}