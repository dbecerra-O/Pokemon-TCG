using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using TcgFront.Models.Auth;

namespace TcgFront.Services
{
    public class AuthService
    {
        // Inject HttpClient and ILocalStorageService dependencies
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        // Constructor to initialize dependencies
        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        // Method to register a new user
        public async Task<string?> Register(RegisterRequest request)
        {
            // Send POST request to register endpoint
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);

            // Check if the registration was successful
            if (result.IsSuccessStatusCode)
            {
                var token = result.Content.ReadAsStringAsync(); // Read the token from the response
                await _localStorage.SetItemAsync("authToken", token); // Store the token in local storage
                await _authStateProvider.GetAuthenticationStateAsync(); // Update the authentication state
                return null; // Return null indicating success
            }

            return "Registration failed."; // Return error message if registration failed
        }

        // Method to log in an existing user
        public async Task<string?> Login(LoginRequest request)
        {
            // Send POST request to login endpoint
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);

            // Check if the login was successful
            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync(); // Read the token from the response
                await _localStorage.SetItemAsync("authToken", token); // Store the token in local storage
                return null; // Return null indicating success
            }

            return "Error logging in. Please verify your credentials."; // Return error message if login failed
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken"); // Remove the token from local storage
            await _authStateProvider.GetAuthenticationStateAsync(); // Update the authentication state
        }

    }
}
