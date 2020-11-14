using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.ModelDto
{
    public class UpdateUserViewModel
    {
        public Result<UserDto> User { get; set; }


        public static UpdateUserViewModel UpdateUserView(Result<UserDto> user)
            => new UpdateUserViewModel
            {
                User = user,
            };
    }
}