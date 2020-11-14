using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Authentication.ModelDto
{
    public class ProfileSideBarViewModel
    {
        public Result<UserDto> User { get; set; }

        public string Url { get; set; }

        public static ProfileSideBarViewModel GetProfileSideBarViewModel(Result<UserDto> user, string url) => new ProfileSideBarViewModel
        {
            User = user,
            Url = url
        };
    }
}