using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using OnlineShop.Application.Common.Interface;

namespace OnlineShop.UI.Core.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("id");
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
