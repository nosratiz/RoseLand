using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserListQueryHandler : PagingService<User>, IRequestHandler<GetUserListQuery, Result<PagedList<UserDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<UserDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users = _context.Users.Where(x => x.Status != Status.Delete)
                .Include(x => x.Role);

            if (!string.IsNullOrWhiteSpace(request.Search))
                users = users.Where(x => x.Email.Contains(request.Search.ToLower())
                                         || x.Name.Contains(request.Search.ToLower())
                                         || x.Family.Contains(request.Search.ToLower()));

            var userList = await GetPagedAsync(request.Page, request.Limit, users);

            return Result<PagedList<UserDto>>.SuccessFull(userList.MapTo<UserDto>(_mapper), new PagingOptions { Limit = request.Limit, Page = request.Page, Search = request.Search });
        }
    }
}