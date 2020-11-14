using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Common.EmailService;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Options;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Authentication.Command
{
    public class RegisterCommand : IRequest<Result>
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStatisticService _statisticService;
        private readonly IDailyStatistic _dailyStatistic;
        private readonly IEmailServices _emailService;
        private readonly IViewRenderServices _viewRenderService;
        private readonly HostAddress _hostAddress;

        public RegisterCommandHandler(ICmsDbContext context, IMapper mapper,
            IEmailServices emailService,
         IViewRenderServices viewRenderService,
         IOptions<HostAddress> hostAddress,
         IStatisticService statisticService,
         IDailyStatistic dailyStatistic)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _viewRenderService = viewRenderService;
            _statisticService = statisticService;
            _dailyStatistic = dailyStatistic;
            _hostAddress = hostAddress.Value;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //add register user to database
            var user = _mapper.Map<User>(request);
            await _context.Users.AddAsync(user, cancellationToken);
            
            
            //increase the stat table
            await _statisticService.UpdateUserCount(true, cancellationToken).ConfigureAwait(false);
            await _dailyStatistic.UpdateRegisterUser(cancellationToken).ConfigureAwait(false);


            //send email verification account
            await _emailService.SendMessage(request.Email, "لینک تایید حساب کاربری",
             await _viewRenderService.RenderToStringAsync("Email/EmailConfirmation",
                  $"{_hostAddress.ConfirmEmail}{user.ActivationCode}"));

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.RegisterSuccessfully)));
        }
    }
}