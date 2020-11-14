using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Queries
{
    public class GetMenuListQueryHandler : PagingService<Domain.Entities.Menu>, IRequestHandler<GetMenuListQuery, Result<PagedList<MenuDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetMenuListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<MenuDto>>> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Menu> menu = _context.Menus.OrderBy(x=>x.SortOrder).Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.Search))
                menu = menu.Where(x => x.UniqueName.Contains(request.Search) || x.Title.Contains(request.Search));

            var menuList = await GetPagedAsync(request.Page, request.Limit, menu);

            return Result<PagedList<MenuDto>>.SuccessFull(menuList.MapTo<MenuDto>(_mapper),request);
        }
    }
}