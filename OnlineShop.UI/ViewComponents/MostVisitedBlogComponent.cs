using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.General.Blog.Queries;

namespace OnlineShop.UI.ViewComponents {
    public class MostVisitedBlogComponent : ViewComponent {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public MostVisitedBlogComponent (IMediator mediator, IMemoryCache memoryCache) {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync () {
            if (!_memoryCache.TryGetValue ("mostVisitedBlog", out var blogs)) {
                blogs = await _mediator.Send (new GetMostVisitedBlogListQuery ());

                _memoryCache.Set ("mostVisitedBlog", blogs, new MemoryCacheEntryOptions ()
                    .SetSlidingExpiration (TimeSpan.FromMinutes (60)));

            }

            return await Task.FromResult ((IViewComponentResult) View ("MostVisitedBlogBox", blogs));
        }
    }
}