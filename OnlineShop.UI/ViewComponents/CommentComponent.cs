using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.Shop.Comments.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class CommentComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public CommentComponent(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }


        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            //if (!_memoryCache.TryGetValue(productId.ToString(), out var comment))
            //{

              var   comment = await _mediator.Send(new GetCommentByProductListQuery { ProductId = productId });

                //_memoryCache.Set(productId.ToString(), comment, new MemoryCacheEntryOptions()
                //    .SetSlidingExpiration(TimeSpan.FromMinutes(10)));
            //}

            return await Task.FromResult((IViewComponentResult)View("CommentBox", comment));
        }
    }
}