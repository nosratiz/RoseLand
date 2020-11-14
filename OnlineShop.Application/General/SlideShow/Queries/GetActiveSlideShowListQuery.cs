using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.SlideShow.ModelDto;

namespace OnlineShop.Application.General.SlideShow.Queries
{
    public class GetActiveSlideShowListQuery : IRequest<List<SlideShowDto>>
    {

    }

    public class GetActiveSlideShowListQueryHandler : IRequestHandler<GetActiveSlideShowListQuery, List<SlideShowDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetActiveSlideShowListQueryHandler(IMapper mapper, ICmsDbContext context)
        {

            _mapper = mapper;
            _context = context;
        }

        public async Task<List<SlideShowDto>> Handle(GetActiveSlideShowListQuery request, CancellationToken cancellationToken)
        {
            var slideShows = await _context.SlideShows.ToListAsync(cancellationToken);

            slideShows.ForEach(x =>
            {
                if (x.EndDateTime.HasValue && x.EndDateTime < DateTime.Now)
                {
                    x.IsVisible = false;
                }
            });

            await _context.SaveAsync(cancellationToken);

            return _mapper.Map<List<SlideShowDto>>(slideShows.Where(x => x.IsVisible));
        }
    }
}