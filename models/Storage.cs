using System.Text.Encodings.Web;
using System.Text.Json;

namespace Westcoast_EShop.Models;

public class Storage
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

    public static void WriteToFile(string path, List<SalesOrder> orders)
    {
        var json = JsonSerializer.Serialize(orders, s_writeOptions);

        File.WriteAllText(path, json);
    }
}
