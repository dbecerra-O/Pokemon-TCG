using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using TcgFront;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri("https://localhost:7291") 
});

builder.Services.AddScoped<TcgFront.Services.AuthService>();
builder.Services.AddScoped<TcgFront.Services.CardService>();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
