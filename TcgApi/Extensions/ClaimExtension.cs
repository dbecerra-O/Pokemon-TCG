using System.Security.Claims;
using TcgApi.Models;

namespace TcgApi.Extensions
{
    public static class ClaimExtension
    {
        // Extension method to get the username from ClaimsPrincipal
        public static string? GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "name")?.Value; // Return the value of the "name" claim
        }
    }
}
