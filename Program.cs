﻿using System.Text.Encodings.Web;
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
            OrderDate = DateTime.Now
        };

        var path = string.Concat(Environment.CurrentDirectory, "/data/salesorder.json");
        var json = JsonSerializer.Serialize(order, s_writeOptions);

        File.WriteAllText(path, json);

        Console.WriteLine(File.ReadAllText(path));

        var salesorder = JsonSerializer.Deserialize<SalesOrder>(json, s_readOptions);
        Console.WriteLine(salesorder);
    }
}