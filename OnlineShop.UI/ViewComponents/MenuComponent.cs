using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.General.AppSetting.Queries;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Application.General.Menu.Queries;

namespace OnlineShop.UI.ViewComponents
{
    public class MenuComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private readonly IShoppingCartService _shoppingCartService;

        public MenuComponent(IMediator mediator, IMemoryCache memoryCache, IShoppingCartService shoppingCartService)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var appSetting = await _mediator.Send(new GetAppSettingQuery());

            var menuList = await _mediator.Send(new GetActiveMenuListQuery());

            var menuViewModel =
                  MenuViewModel.GetMenuViewModel(appSetting.Data, menuList, _shoppingCartService.GetCustomerShoppingCartViewModelList());



            return await Task.FromResult((IViewComponentResult)View("MenuSection", menuViewModel));
        }
    }
}