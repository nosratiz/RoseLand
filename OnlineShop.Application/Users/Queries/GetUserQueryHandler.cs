using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<UserDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Delete, cancellationToken);

            if (user is null)
                return Result<UserDto>.Failed(new ApiMessage(ResponseMessage.UserNotFound));

            return Result<UserDto>.SuccessFull(_mapper.Map<UserDto>(user));
        }
    }
}