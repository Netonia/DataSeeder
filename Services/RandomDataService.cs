using Bogus;
using DataSeeder.Models;
using System.Text.Json;

namespace DataSeeder.Services;

public class RandomDataService
{
    private readonly Faker _faker = new Faker();
    
    public List<Dictionary<string, object>> GenerateData(List<FieldDefinition> fields, int count)
    {
        var result = new List<Dictionary<string, object>>();
        
        for (int i = 0; i < count; i++)
        {
            var row = new Dictionary<string, object>();
            
            foreach (var field in fields)
            {
                row[field.Name] = GenerateFieldValue(field);
            }
            
            result.Add(row);
        }
        
        return result;
    }
    
    private object GenerateFieldValue(FieldDefinition field)
    {
        return field.Type switch
        {
            FieldType.String => field.MaxLength.HasValue 
                ? _faker.Random.String2(field.MinLength ?? 5, field.MaxLength.Value)
                : _faker.Lorem.Word(),
            
            FieldType.Integer => field.MinValue.HasValue && field.MaxValue.HasValue
                ? _faker.Random.Int(field.MinValue.Value, field.MaxValue.Value)
                : _faker.Random.Int(1, 1000),
            
            FieldType.Decimal => field.MinValue.HasValue && field.MaxValue.HasValue
                ? _faker.Random.Decimal(field.MinValue.Value, field.MaxValue.Value)
                : _faker.Random.Decimal(1, 1000),
            
            FieldType.Boolean => _faker.Random.Bool(),
            
            FieldType.Date => _faker.Date.Past(5),
            
            FieldType.Email => _faker.Internet.Email(),
            
            FieldType.FirstName => _faker.Name.FirstName(),
            
            FieldType.LastName => _faker.Name.LastName(),
            
            FieldType.FullName => _faker.Name.FullName(),
            
            FieldType.City => _faker.Address.City(),
            
            FieldType.Country => _faker.Address.Country(),
            
            FieldType.PhoneNumber => _faker.Phone.PhoneNumber(),
            
            FieldType.Address => _faker.Address.FullAddress(),
            
            FieldType.UUID => Guid.NewGuid().ToString(),
            
            FieldType.CompanyName => _faker.Company.CompanyName(),
            
            FieldType.JobTitle => _faker.Name.JobTitle(),
            
            _ => _faker.Lorem.Word()
        };
    }
}
