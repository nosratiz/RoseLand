using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OnlineShop.Application.General.SlideShow.Queries;
using OnlineShop.Application.Shop.Comments.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class RelatedProductComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public RelatedProductComponent(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int productId)
        {
            if (!_memoryCache.TryGetValue(JsonConvert.SerializeObject(new GetRelatedProductQuery { CategoryId = categoryId, ProductId = productId }), out var productList))
            {

                productList = await _mediator.Send(new GetRelatedProductQuery { CategoryId = categoryId, ProductId = productId });

                _memoryCache.Set(JsonConvert.SerializeObject(new GetRelatedProductQuery { CategoryId = categoryId, ProductId = productId }), productList, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(60)));
            }

            return await Task.FromResult((IViewComponentResult)View("RelatedProductBox", productList));
        }
    }
}