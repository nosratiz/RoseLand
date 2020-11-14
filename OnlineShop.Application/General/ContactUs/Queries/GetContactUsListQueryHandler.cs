using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.ContactUs.Queries
{
    public class GetContactUsListQueryHandler : PagingService<Domain.Entities.ContactUs>, IRequestHandler<GetContactUsListQuery, Result<PagedList<ContactUsDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetContactUsListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ContactUsDto>>> Handle(GetContactUsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.ContactUs> contactUses = _context.ContactUses;

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                contactUses = contactUses.Where(x =>
                    x.Name.Contains(request.Search) || x.Email.ToLower().Contains(request.Search) ||
                    x.Message.Contains(request.Search));
            }

            var contactUsList = await GetPagedAsync(request.Page, request.Limit, contactUses);

            return Result<PagedList<ContactUsDto>>.SuccessFull(contactUsList.MapTo<ContactUsDto>(_mapper), request);
        }


    }
}