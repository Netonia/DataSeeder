using DataSeeder.Models;
using System.Text;
using System.Text.Json;

namespace DataSeeder.Services;

public class ExportService
{
    public string ExportToCsv(List<Dictionary<string, object>> data)
    {
        if (data.Count == 0) return string.Empty;
        
        var sb = new StringBuilder();
        
        // Header
        var headers = data[0].Keys;
        sb.AppendLine(string.Join(",", headers.Select(h => EscapeCsvValue(h))));
        
        // Rows
        foreach (var row in data)
        {
            var values = headers.Select(h => EscapeCsvValue(row[h]?.ToString() ?? ""));
            sb.AppendLine(string.Join(",", values));
        }
        
        return sb.ToString();
    }
    
    public string ExportToJson(List<Dictionary<string, object>> data)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        return JsonSerializer.Serialize(data, options);
    }
    
    public string ExportToSql(List<Dictionary<string, object>> data, string tableName = "GeneratedData")
    {
        if (data.Count == 0) return string.Empty;
        
        var sb = new StringBuilder();
        
        // Create table statement
        var headers = data[0].Keys;
        sb.AppendLine($"CREATE TABLE {tableName} (");
        sb.AppendLine(string.Join(",\n", headers.Select(h => $"    {h} VARCHAR(255)")));
        sb.AppendLine(");");
        sb.AppendLine();
        
        // Insert statements
        foreach (var row in data)
        {
            var values = headers.Select(h => EscapeSqlValue(row[h]?.ToString() ?? ""));
            sb.AppendLine($"INSERT INTO {tableName} ({string.Join(", ", headers)}) VALUES ({string.Join(", ", values)});");
        }
        
        return sb.ToString();
    }
    
    private string EscapeCsvValue(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
        return value;
    }
    
    private string EscapeSqlValue(string value)
    {
        return $"'{value.Replace("'", "''")}'";
    }
}
