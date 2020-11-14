using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IStatisticService _statisticService;



        public DeleteUserCommandHandler(ICmsDbContext context, ICurrentUserService currentUser, IStatisticService statisticService)
        {
            _context = context;
            _currentUser = currentUser;
            _statisticService = statisticService;
        }

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Delete, cancellationToken);

            if (user is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.UserNotFound)));


            //if (request.Id == long.Parse(_currentUser.UserId))
            //    return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.InvalidDelete)));

            if (user.RoleId == Role.Admin)
                return Result.Failed(new BadRequestObjectResult(new ApiMessage(ResponseMessage.CanNotDeleteAdmin)));

            user.Status = Status.Delete;

            await _statisticService.UpdateUserCount(false, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull();

        }
    }
}