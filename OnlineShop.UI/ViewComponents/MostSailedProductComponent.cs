using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.Shop.Products.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class MostSailedProductComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public MostSailedProductComponent(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_memoryCache.TryGetValue("MostSailedProduct", out var products))
            {
                products = await _mediator.Send(new GetMostSailedProductListQuery { Limit = 6 });

                _memoryCache.Set("MostSailedProduct", products, new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromMinutes(20)));
            }

            return await Task.FromResult((IViewComponentResult)View("MostSailedProductBox", products));
        }
    }
}