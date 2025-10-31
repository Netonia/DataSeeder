using Fluid;
using System.Text.Json;

namespace DataSeeder.Services;

public class TemplateService
{
    private readonly FluidParser _parser;
    
    public TemplateService()
    {
        _parser = new FluidParser();
    }
    
    public async Task<string> RenderTemplateAsync(string template, List<Dictionary<string, object>> data)
    {
        try
        {
            if (_parser.TryParse(template, out var fluidTemplate, out var error))
            {
                var context = new TemplateContext(new { items = data });
                context.Options.MemberAccessStrategy.Register<Dictionary<string, object>>();
                
                var result = await fluidTemplate.RenderAsync(context);
                return result;
            }
            else
            {
                return $"Template error: {error}";
            }
        }
        catch (Exception ex)
        {
            return $"Error rendering template: {ex.Message}";
        }
    }
    
    public async Task<string> RenderSingleRowAsync(string template, Dictionary<string, object> data)
    {
        try
        {
            if (_parser.TryParse(template, out var fluidTemplate, out var error))
            {
                var context = new TemplateContext(data);
                context.Options.MemberAccessStrategy.Register<Dictionary<string, object>>();
                
                var result = await fluidTemplate.RenderAsync(context);
                return result;
            }
            else
            {
                return $"Template error: {error}";
            }
        }
        catch (Exception ex)
        {
            return $"Error rendering template: {ex.Message}";
        }
    }
}
