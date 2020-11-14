using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Authentication.Command
{
    public class ResetPasswordCommand : IRequest<Result>
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public ResetPasswordCommandHandler(ICmsDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x =>
                x.Id == long.Parse(_currentUserService.UserId) && x.Status == Status.Active, cancellationToken);

            if (!PasswordManagement.CheckPassword(request.OldPassword, user.Password))
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.WrongPassword)));

            user.Password = PasswordManagement.HashPass(request.NewPassword);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));
        }
    }
}