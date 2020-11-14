using System.Security.Claims;

namespace OnlineShop.UI.Core
{
    public class AppUserLogin : ClaimsPrincipal
    {
        public AppUserLogin(ClaimsPrincipal principal)
            : base(principal)
        {
        }
        public string Name => FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public int UserId => int.Parse(FindFirst("id").Value);

        public int RoleId => int.Parse(FindFirst(ClaimTypes.Role).Value);

        public string Email => FindFirst(ClaimTypes.Email)?.Value;


    }
}