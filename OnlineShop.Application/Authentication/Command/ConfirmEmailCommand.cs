using System;
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
    public partial class ConfirmEmailCommand : IRequest<Result>
    {
        public Guid ActiveCode { get; set; }
    }

    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Result>
    {
        private readonly ICmsDbContext _context;

        public ConfirmEmailCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.ActivationCode == request.ActiveCode
                                                                      && x.Status != Status.Delete, cancellationToken);
            if (user is null)
                return Result.Failed(new ApiMessage(ResponseMessage.AccountNotConfirm));

            if (user.ExpiredVerification <= DateTime.Now)
                return Result.Failed(new ApiMessage(ResponseMessage.ExpiredCode));

            user.IsEmailConfirmed = true;
            user.Status = Status.Active;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new ApiMessage(ResponseMessage.AccountVerify));
        }
    }
}