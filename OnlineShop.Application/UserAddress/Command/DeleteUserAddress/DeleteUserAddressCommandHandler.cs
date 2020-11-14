using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.UserAddress.Command.DeleteUserAddress
{
    public class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserAddressCommandHandler(ICmsDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(x => x.UserId == int.Parse(_currentUserService.UserId) && x.Id == request.Id && !x.IsDeleted, cancellationToken);


            if (userAddress is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.UserAddressNotFound)));

            if (userAddress.UserId!=int.Parse(_currentUserService.UserId))
                return Result.Failed(new UnauthorizedObjectResult(new ApiMessage(ResponseMessage.UnAuthorized)));
            
            
            userAddress.IsDeleted = true;

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.DeleteSuccessfully)));
        }
    }
}