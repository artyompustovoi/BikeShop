using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NiceBikeShopBlazorFrontend;
using MudBlazor.Services;
using NiceBikeShopBlazorFrontend.Models;
using NiceBikeShop.HttpApiClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient()
{
    Timeout = TimeSpan.FromSeconds(5)
});

builder.Services.AddSingleton(provider => 
new NiceBikeShopClient(provider.GetRequiredService<HttpClient>(), "https://localhost:7287"));

builder.Services.AddMudServices();

builder.Services.AddScoped<ICatalog, InMemoryCatalog>();
builder.Services.AddScoped<ICart, Cart>();
await builder.Build().RunAsync();
