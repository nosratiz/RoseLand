using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.General.Blog.Queries;

namespace OnlineShop.UI.ViewComponents
{

    public class BlogComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public BlogComponent(IMemoryCache memoryCache, IMediator mediator)
        {
            _memoryCache = memoryCache;
            _mediator = mediator;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_memoryCache.TryGetValue("Blog", out var blogs))
            {
                blogs = await _mediator.Send(new GetLatestBlogListQuery { Limit = 2 });

                _memoryCache.Set("Blog", blogs, new MemoryCacheEntryOptions()
                                              .SetSlidingExpiration(TimeSpan.FromMinutes(10)));
            }
            return await Task.FromResult((IViewComponentResult)View("BlogBox", blogs));
        }
    }
}