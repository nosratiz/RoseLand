using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.UI.Filter
{
    public class AdminAuthorization : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly ICmsDbContext _context;

        public AdminAuthorization(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userId = GetUserName(context.HttpContext.User);

            if (string.IsNullOrWhiteSpace(userId))
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "account", action = "Login", Areas = "adminPanel" }));
            
            else
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == int.Parse(userId) && x.Status == Status.Active);

                if (user.RoleId == Role.User)
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "account", action = "Login", Areas = "adminPanel" }));
                
            }
        }

        private string GetUserName(IPrincipal user)
        {
            var identity = (ClaimsIdentity)user.Identity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                return claims.FirstOrDefault(x => x.Type == "id")?.Value;
            }

            return string.Empty;
        }
    }
}