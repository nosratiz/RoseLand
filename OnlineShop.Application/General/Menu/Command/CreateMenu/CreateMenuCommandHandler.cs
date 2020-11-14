using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Menu.Command.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Result<MenuDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<MenuDto>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = _mapper.Map<Domain.Entities.Menu>(request);

            await _context.Menus.AddAsync(menu, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<MenuDto>.SuccessFull(_mapper.Map<MenuDto>(menu));
        }
    }
}