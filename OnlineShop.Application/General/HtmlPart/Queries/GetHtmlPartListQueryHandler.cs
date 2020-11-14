using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.HtmlPart.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.HtmlPart.Queries
{
    public class GetHtmlPartListQueryHandler : PagingService<Domain.Entities.HtmlPart>, IRequestHandler<GetHtmlPartListQuery, Result<PagedList<HtmlPartDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetHtmlPartListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<HtmlPartDto>>> Handle(GetHtmlPartListQuery request, CancellationToken cancellationToken)
        {
            var htmlPartList = await GetPagedAsync(request.Page, request.Limit, _context.HtmlParts);

            return Result<PagedList<HtmlPartDto>>.SuccessFull(htmlPartList.MapTo<HtmlPartDto>(_mapper));
        }
    }
}