using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.UserAddress.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.UserAddress.Queries
{
    public class GetUserAddressQuery : IRequest<Result<UserAddressDto>>
    {
        public int Id { get; set; }
    }


    public class GetUserAddressQueryHandler : IRequestHandler<GetUserAddressQuery, Result<UserAddressDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetUserAddressQueryHandler(ICmsDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Result<UserAddressDto>> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
        {
            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(x => x.Id == request.Id && x.UserId == int.Parse(_currentUserService.UserId) && !x.IsDeleted, cancellationToken);

            if (userAddress is null)
                return Result<UserAddressDto>.Failed(new NotFoundObjectResult(new ApiMessage()));

            return Result<UserAddressDto>.SuccessFull(_mapper.Map<UserAddressDto>(userAddress));
        }
    }
}