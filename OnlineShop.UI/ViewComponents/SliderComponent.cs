using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.General.SlideShow.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class SliderComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public SliderComponent(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(!_memoryCache.TryGetValue("slideShow",out var activeslideShow)){

                activeslideShow = await _mediator.Send(new GetActiveSlideShowListQuery());

                 _memoryCache.Set("slideShow", activeslideShow, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(60)));
            }

            return await Task.FromResult((IViewComponentResult)View("SlideBox",activeslideShow));
        }
    }
}