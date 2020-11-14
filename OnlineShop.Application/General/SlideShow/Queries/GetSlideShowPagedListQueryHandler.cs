using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Queries
{
    public class GetSlideShowPagedListQueryHandler : PagingService<Domain.Entities.SlideShow>, IRequestHandler<GetSlideShowPagedListQuery, Result<PagedList<SlideShowDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetSlideShowPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<SlideShowDto>>> Handle(GetSlideShowPagedListQuery request, CancellationToken cancellationToken)
        {
            var slideShowList = await GetPagedAsync(request.Page, request.Limit, _context.SlideShows);

            return Result<PagedList<SlideShowDto>>.SuccessFull(slideShowList.MapTo<SlideShowDto>(_mapper), request);
        }
    }
}