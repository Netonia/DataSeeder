namespace DataSeeder.Models;

public class FieldDefinition
{
    public string Name { get; set; } = string.Empty;
    public FieldType Type { get; set; }
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }
}
