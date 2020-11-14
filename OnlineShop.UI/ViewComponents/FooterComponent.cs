using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.General.AppSetting.Queries;
using OnlineShop.Application.General.Footer;

namespace OnlineShop.UI.ViewComponents {
    public class FooterComponent : ViewComponent {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public FooterComponent (IMediator mediator, IMemoryCache memoryCache) {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync () {
            if (!_memoryCache.TryGetValue ("footer", out var footerViewModel)) {
                var appSetting = await _mediator.Send (new GetAppSettingQuery ());

                footerViewModel = FooterViewModel.GetFooterViewModel (appSetting.Data);

                _memoryCache.Set ("footer", footerViewModel, new MemoryCacheEntryOptions ()
                    .SetSlidingExpiration (TimeSpan.FromMinutes (10)));
            }

            return await Task.FromResult ((IViewComponentResult) View ("Footer", footerViewModel));
        }

    }
}