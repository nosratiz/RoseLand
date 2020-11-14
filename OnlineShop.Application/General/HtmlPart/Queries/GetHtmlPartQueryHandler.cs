using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.HtmlPart.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.HtmlPart.Queries
{
    public class GetHtmlPartQueryHandler : IRequestHandler<GetHtmlPartQuery, Result<HtmlPartDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetHtmlPartQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<HtmlPartDto>> Handle(GetHtmlPartQuery request, CancellationToken cancellationToken)
        {
            var htmlPart = await _context.HtmlParts.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (htmlPart is null)
                return Result<HtmlPartDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.ContentNotFound)));


            return Result<HtmlPartDto>.SuccessFull(_mapper.Map<HtmlPartDto>(htmlPart));
        }
    }
}