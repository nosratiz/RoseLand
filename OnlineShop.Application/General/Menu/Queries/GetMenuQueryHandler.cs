using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Queries
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, Result<MenuDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetMenuQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<MenuDto>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

            if (menu is null)
                return Result<MenuDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.MenuNotFound)));

            return Result<MenuDto>.SuccessFull(_mapper.Map<MenuDto>(menu));
        }
    }
}