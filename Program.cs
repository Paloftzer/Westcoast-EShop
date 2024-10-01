using Westcoast_EShop.Models;
using static Westcoast_EShop.Models.Storage;

namespace Westcoast_EShop;

class Program
{
    static void Main()
    {
        var orders = new List<SalesOrder>();

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

        var product = new Product()
        {
            ProductId = 1,
            ItemNumber = "1-00001",
            Name = "First Product",
            Price = 1000
        };
        var orderItem = new OrderItem()
        {
            Quantity = 40,
            Discount = 0.10m,
            Product = product
        };
        orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

        order.OrderItems = [];
        order.OrderItems.Add(orderItem);

        product = new Product()
        {
            ProductId = 2,
            ItemNumber = "1-00002",
            Name = "Second Product",
            Price = 3750
        };
        orderItem = new OrderItem()
        {
            Quantity = 25,
            Discount = 0.175m,
            Product = product
        };
        orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

        order.OrderItems.Add(orderItem);

        orders.Add(order);

        /* Orders p2 */
        order = new()
        {
            OrderId = "987654321",
            OrderDate = DateTime.Now,
            Customer = new Customer
            {
                CustomerId = 987654321,
                CreationDate = DateTime.Now,
                LastPurchase = DateTime.Now,
                FirstName = "Doe",
                LastName = "John",
                AddressLine = "London",
                PostalCode = "88 555",
                City = "1st Street"
            }
        };

        product = new Product()
        {
            ProductId = 3,
            ItemNumber = "1-00003",
            Name = "Third Product",
            Price = 890
        };
        orderItem = new OrderItem()
        {
            Quantity = 12,
            Discount = 0.15m,
            Product = product
        };
        orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

        order.OrderItems = [];
        order.OrderItems.Add(orderItem);

        product = new Product()
        {
            ProductId = 4,
            ItemNumber = "1-00004",
            Name = "Fourth Product",
            Price = 27.50m
        };
        orderItem = new OrderItem()
        {
            Quantity = 70,
            Discount = 0.30m,
            Product = product
        };
        orderItem.LineSum = orderItem.Quantity * (orderItem.Product.Price - (orderItem.Discount * orderItem.Product.Price));

        order.OrderItems.Add(orderItem);

        orders.Add(order);

        var path = string.Concat(Environment.CurrentDirectory, "/data/orders.json");

        WriteToFile(path, orders);

        var ordersFromFile = ReadFromFile(path);
        Console.WriteLine("\n", "Orders", "\n");

        foreach (var item in ordersFromFile)
        {
            Console.WriteLine(item);
        }

        foreach (var item in order.OrderItems)
        {
            Console.WriteLine(item);
        }
    }
}