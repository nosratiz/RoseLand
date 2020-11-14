using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Faq.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Faq.Queries
{
    public class GetFaqQueryHandler : IRequestHandler<GetFaqQuery, Result<FaqDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetFaqQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<FaqDto>> Handle(GetFaqQuery request, CancellationToken cancellationToken)
        {
            var faq = await _context.Faqs.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (faq is null)
                return Result<FaqDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ContentNotFound)));

            return Result<FaqDto>.SuccessFull(_mapper.Map<FaqDto>(faq));
        }
    }
}