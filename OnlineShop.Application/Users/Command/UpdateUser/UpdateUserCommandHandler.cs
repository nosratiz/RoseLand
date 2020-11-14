using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {

        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Delete, cancellationToken);

            if (user is null)
                return Result.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.UserNotFound)));

            _mapper.Map(request, user);

            _context.Users.Update(user);

            await _context.SaveAsync(cancellationToken);

            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));

        }
    }
}