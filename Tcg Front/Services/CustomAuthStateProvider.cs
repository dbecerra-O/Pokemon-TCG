using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace TcgFront.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        // Inject dependencies
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        // Constructor to initialize dependencies
        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        // Override method to get the current authentication state
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Retrieve the JWT token from local storage
            string token = await _localStorage.GetItemAsStringAsync("authToken");

            // Create a new ClaimsIdentity and set the Authorization header to null
            var identity = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    // Parse the claims from the JWT token and create a new ClaimsIdentity
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt", "name", "email");
                    // Set the Authorization header with the Bearer token for future HTTP requests
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }
                catch
                {
                    // Log the error or handle it as needed
                    await _localStorage.RemoveItemAsync("authToken");
                    identity = new ClaimsIdentity();
                }
            }

            // Create a new ClaimsPrincipal with the identity and return the authentication state
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            return state;
        }

        // Method to parse claims from a JWT token
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            // Split the JWT token and extract the payload (the second part)
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        // Method to parse a Base64 string without padding
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            // Add padding to the Base64 string if necessary
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
