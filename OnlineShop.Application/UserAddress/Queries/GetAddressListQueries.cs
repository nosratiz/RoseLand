using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.UserAddress.ModelDto;

namespace OnlineShop.Application.UserAddress.Queries
{
    public class GetAddressListQueries : IRequest<List<UserAddressDto>>
    {
        public long UserId { get; set; }
    }

    public class GetAddressListQueriesHandler : IRequestHandler<GetAddressListQueries, List<UserAddressDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressListQueriesHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserAddressDto>> Handle(GetAddressListQueries request, CancellationToken cancellationToken)
        {
            var userAddressList = await _context.UserAddresses
                .Include(x => x.User)
                .Where(x => !x.IsDeleted && x.UserId == request.UserId).OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<UserAddressDto>>(userAddressList);
        }
    }
}