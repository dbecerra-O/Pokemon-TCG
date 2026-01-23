using System.Security.Claims;
using Tcg_web.Models;

namespace Tcg_web.Extensions
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
