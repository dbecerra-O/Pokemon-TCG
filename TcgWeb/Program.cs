using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using TcgWeb;
using Microsoft.AspNetCore.Components.Authorization;
using TcgWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var apiUrl = builder.Configuration["ApiBaseUrl"] ?? string.Empty;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri(apiUrl) 
});

builder.Services.AddScoped<TcgWeb.Services.AuthService>();
builder.Services.AddScoped<TcgWeb.Services.CardService>();
builder.Services.AddScoped<TcgWeb.Services.PackService>();
builder.Services.AddScoped<TcgWeb.Services.UserService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
await builder.Build().RunAsync();
