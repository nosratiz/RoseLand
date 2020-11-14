using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Command.CreateSlideShow
{
    public class CreateSlideShowCommandHandler : IRequestHandler<CreateSlideShowCommand, Result<SlideShowDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public CreateSlideShowCommandHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<SlideShowDto>> Handle(CreateSlideShowCommand request, CancellationToken cancellationToken)
        {
            var slideShow = _mapper.Map<Domain.Entities.SlideShow>(request);

            await _context.SlideShows.AddAsync(slideShow, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return Result<SlideShowDto>.SuccessFull(_mapper.Map<SlideShowDto>(slideShow));
        }
    }
}