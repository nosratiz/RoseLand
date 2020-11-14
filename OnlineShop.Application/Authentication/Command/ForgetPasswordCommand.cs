using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.EmailService;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Options;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Authentication.Command
{
    public class ForgetPasswordCommand : IRequest<Result<User>>
    {
        public string Email { get; set; }
    }

    public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, Result<User>>
    {
        private readonly ICmsDbContext _context;
        private readonly IEmailServices _emailServices;
        private readonly IViewRenderServices _viewRenderServices;
        private readonly HostAddress _hostAddress;

        public ForgetPasswordCommandHandler(ICmsDbContext context, IEmailServices emailServices
            , IViewRenderServices viewRenderServices, IOptions<HostAddress> hostAddress)
        {
            _context = context;
            _emailServices = emailServices;
            _viewRenderServices = viewRenderServices;
            _hostAddress = hostAddress.Value;
        }

        public async Task<Result<User>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.Email == request.Email && x.Status == Status.Active, cancellationToken);

            if (user is null)
                return Result<User>.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.ForgotPasswordSuccessfullySent)));

            user.ExpiredVerification = DateTime.Now.AddDays(2);
            user.ActivationCode = Guid.NewGuid();

            await _emailServices.SendMessage(request.Email, "فراموشی رمز عبور", await
                _viewRenderServices.RenderToStringAsync("Email/ResetPasswordMail", $"{_hostAddress.ForgotPassword}{user.ActivationCode}"));

            await _context.SaveAsync(cancellationToken);

            return Result<User>.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.ForgotPasswordSuccessfullySent)));


        }
    }
}