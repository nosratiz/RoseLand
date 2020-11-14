using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Faq.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Faq.Queries
{
    public class GetFaqListQueryHandler : PagingService<Domain.Entities.Faq>, IRequestHandler<GetFaqListQuery, Result<PagedList<FaqDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetFaqListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<FaqDto>>> Handle(GetFaqListQuery request, CancellationToken cancellationToken)
        {
            var faqList = await GetPagedAsync(request.Page, request.Limit, _context.Faqs);

            return Result<PagedList<FaqDto>>.SuccessFull(faqList.MapTo<FaqDto>(_mapper));
        }
    }
}