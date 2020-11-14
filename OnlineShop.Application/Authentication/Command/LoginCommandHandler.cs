using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Authentication.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<User>>
    {
        private readonly ICmsDbContext _context;


        public LoginCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result<User>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(
                x => x.Email == request.Email && x.Status != Status.Delete, cancellationToken);

            if (user is null)
                return Result<User>.Failed(new ApiMessage(ResponseMessage.InvalidUserCredential));

            if (!PasswordManagement.CheckPassword(request.Password, user.Password))
                return Result<User>.Failed(new ApiMessage(ResponseMessage.InvalidUserCredential));

            if (!user.IsEmailConfirmed || user.Status != Status.Active)
                return Result<User>.Failed(new ApiMessage(ResponseMessage.UserIsDeActive));
            

            return Result<User>.SuccessFull(user);
        }
    }
}