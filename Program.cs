using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DataSeeder;
using DataSeeder.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add DataSeeder services
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<RandomDataService>();
builder.Services.AddScoped<TemplateService>();
builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<ExportService>();

await builder.Build().RunAsync();
