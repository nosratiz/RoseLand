using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.Shop.Products.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class MostVisitedProductComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public MostVisitedProductComponent(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_memoryCache.TryGetValue("MostVisitedProduct", out var products))
            {
                products = await _mediator.Send(new GetMostVisitedProductListQuery { Limit = 6 });

                _memoryCache.Set("MostVisitedProduct", products, new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromMinutes(20)));
            }

            return await Task.FromResult((IViewComponentResult)View("MostVisitedProductBox", products));
        }


    }
}