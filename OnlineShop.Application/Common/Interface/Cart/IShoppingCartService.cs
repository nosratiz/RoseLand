using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Application.Shop.Cart.ModelDto;

namespace OnlineShop.Application.Common.Interface.Cart
{
    public interface IShoppingCartService
    {
        List<CreateShoppingCartViewModel> GetCustomerShoppingCartViewModelList();

        List<CreateShoppingCartViewModel> UpdateShoppingCartCountFromCookie(List<CreateShoppingCartViewModel> createCustomerShoppingCartView, int productVariantId, int count);

        List<CreateShoppingCartViewModel> DeleteShoppingCartFromCookie(List<CreateShoppingCartViewModel> createCustomerShoppingCartView, int productVariantId);
        List<CreateShoppingCartViewModel> DeleteShoppingCartFromCookie(int productVariantId);

        List<CreateShoppingCartViewModel> DeleteShoppingCartCookie();
        Task<List<CreateShoppingCartViewModel>> CreateShoppingCartCookie(List<CreateShoppingCartViewModel> createCustomerShoppingCartView, CreateShoppingCartViewModel shoppingCartViewModel);
        bool IsProductExistInShopCart(int productVariantId);
        bool IsShoppingCartInfoExist();
        int CustomerShoppingCartCookieCount();
        void ExpireShoppingCartCookie();
    }
}