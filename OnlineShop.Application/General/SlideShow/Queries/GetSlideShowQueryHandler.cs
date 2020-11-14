using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Queries
{
    public class GetSlideShowQueryHandler : IRequestHandler<GetSlideShowQuery, Result<SlideShowDto>>
    {

        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetSlideShowQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<SlideShowDto>> Handle(GetSlideShowQuery request, CancellationToken cancellationToken)
        {
            var slideShow = await _context.SlideShows.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (slideShow is null)
                return Result<SlideShowDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.SlideShowNotFound)));

            return Result<SlideShowDto>.SuccessFull(_mapper.Map<SlideShowDto>(slideShow));
        }
    }
}