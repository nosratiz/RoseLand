using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.UI.Core
{
    public class AccountManager
    {

        public static async Task SignIn(HttpContext httpContext, User users)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaim(users), CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(5)

            });
        }

        public static async Task SignOut(HttpContext httpContext) => await httpContext.SignOutAsync();


        private static IEnumerable<Claim> GetUserClaim(User users) => new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, users.Name),
                new Claim("id", users.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{users.Name} {users.Family}")
            };
    }
}