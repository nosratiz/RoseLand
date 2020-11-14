using System.Collections.Generic;
using OnlineShop.Application.General.AppSetting.ModelDto;
using OnlineShop.Application.Shop.Cart.ModelDto;

namespace OnlineShop.Application.General.Menu.ModelDto
{
    public class MenuViewModel
    {
        public AppSettingDto AppSettingDto { get; set; }

        public List<MenuDto> Menu { get; set; }

        public List<CreateShoppingCartViewModel> BasketShopViewModel { get; set; }


        public static MenuViewModel GetMenuViewModel(AppSettingDto appSetting, List<MenuDto> menu, List<CreateShoppingCartViewModel> basketShopViewModels) => new MenuViewModel
        {
            AppSettingDto = appSetting,
            Menu = menu,
            BasketShopViewModel = basketShopViewModels
        };
    }
}