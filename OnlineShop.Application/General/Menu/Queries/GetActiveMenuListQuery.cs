using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Menu.ModelDto;

namespace OnlineShop.Application.General.Menu.Queries
{
    public class GetActiveMenuListQuery : IRequest<List<MenuDto>>
    {

    }


    public class GetActiveMenuListQueryHandler :IRequestHandler<GetActiveMenuListQuery,List<MenuDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetActiveMenuListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MenuDto>> Handle(GetActiveMenuListQuery request, CancellationToken cancellationToken)
        {
            var menus = await _context.Menus.Where(x => !x.IsDeleted && x.IsPublish).OrderBy(x=>x.SortOrder).ToListAsync(cancellationToken);

            return _mapper.Map<List<MenuDto>>(menus);
        }
    }
}