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

namespace OnlineShop.Application.UserAddress.Queries
{
    public class GetAddressQuery : IRequest<Result<UserAddressDto>>
    {
        public int Id { get; set; }
    }


    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Result<UserAddressDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<UserAddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (userAddress is null)
                return Result<UserAddressDto>.Failed(new NotFoundObjectResult(new ApiMessage()));

            return Result<UserAddressDto>.SuccessFull(_mapper.Map<UserAddressDto>(userAddress));
        }
    }
}