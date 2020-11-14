using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStatisticService _statisticService;
        private readonly IDailyStatistic _dailyStatistic;

        public CreateUserCommandHandler(ICmsDbContext context, IMapper mapper, IStatisticService statisticService, IDailyStatistic dailyStatistic)
        {
            _context = context;
            _mapper = mapper;
            _statisticService = statisticService;
            _dailyStatistic = dailyStatistic;
        }

        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _context.Users.AddAsync(user, cancellationToken);

            await _statisticService.UpdateUserCount(true, cancellationToken);
          
            await _dailyStatistic.UpdateRegisterUser(cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<UserDto>.SuccessFull(_mapper.Map<UserDto>(user));


        }
    }
}