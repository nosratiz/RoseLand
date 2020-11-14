using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.Shop.Cart.ModelDto;
namespace OnlineShop.Application.Shop.Cart.Queries
{
    public class GetBasketListQueries : IRequest<List<BasketShopViewModel>>
    {

    }


    public class GetBasketListQueriesHandler : IRequestHandler<GetBasketListQueries, List<BasketShopViewModel>>
    {
        private readonly ICmsDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;

        public GetBasketListQueriesHandler(ICmsDbContext context, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<List<BasketShopViewModel>> Handle(GetBasketListQueries request, CancellationToken cancellationToken)
        {
            var shoppingCart = _shoppingCartService.GetCustomerShoppingCartViewModelList();

            List<BasketShopViewModel> basketShopView = new List<BasketShopViewModel>();

            foreach (var item in shoppingCart)
            {
                var productVariant = await _context.ProductVariants.Include(x => x.Product)
                    .SingleOrDefaultAsync(p => p.Id == item.ProductVariantId, cancellationToken);

                if (productVariant != null)
                    basketShopView.Add(BasketShopViewModel.GetBasketShopViewModel(item, productVariant));
            }


            return basketShopView;
        }
    }
}