using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<BlogCategoryDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<BlogCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.BlogCategory>(request);

            await _context.BlogCategories.AddAsync(category, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<BlogCategoryDto>.SuccessFull(_mapper.Map<BlogCategoryDto>(category));
        }
    }
}