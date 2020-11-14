using System;
using System.Linq;
using System.Security.Claims;

namespace OnlineShop.UI.Core.Extensions
{
    public static class UserClaimsExtensions
    {
        public static int? UserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.Identity.IsAuthenticated)
                return int.Parse(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "id")?.Value);

            return null;
        }

        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
            => int.Parse(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "id")?.Value);



        public static int GetRoleId(this ClaimsPrincipal claimsPrincipal)
            => int.Parse(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "RoleId")?.Value);

        public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;
    }
}