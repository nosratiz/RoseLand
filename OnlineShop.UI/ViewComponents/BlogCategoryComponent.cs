using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.General.BlogCategory.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class BlogCategoryComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public BlogCategoryComponent(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_memoryCache.TryGetValue("BlogCategory", out var categories))
            {
                categories = await _mediator.Send(new GetBlogCategoryListQuery());

                _memoryCache.Set("BlogCategory", categories, new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromMinutes(10)));

            }

            return await Task.FromResult((IViewComponentResult)View("CategoryBox", categories));
        }
    }
}