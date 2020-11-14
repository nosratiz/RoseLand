using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.Search;
using OnlineShop.Application.Search.Command;
using OnlineShop.Application.Shop.Cart.ModelDto;
using OnlineShop.Application.Shop.Comments.Command.CreateCommentCommand;
using OnlineShop.Application.Shop.DiscountCodes.Command.ApplyDiscountCode;
using OnlineShop.Application.Shop.Orders.Command.DeleteUserOrderItem;
using OnlineShop.Application.Shop.Orders.Queries;

namespace OnlineShop.UI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class SiteController : BaseController
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IShoppingCartService _shoppingCartService;

        public SiteController(IMemoryCache memoryCache, IShoppingCartService shoppingCartService)
        {
            _memoryCache = memoryCache;
            _shoppingCartService = shoppingCartService;
        }


        [HttpGet("Search")]
        public async Task<IActionResult> Search(string query)
        {

            if (!_memoryCache.TryGetValue(query, out var searchList))
            {
                searchList = await Mediator.Send(new SearchCommand { Query = query });

                _memoryCache.Set(query, searchList, new MemoryCacheEntryOptions()
                         .SetSlidingExpiration(TimeSpan.FromMinutes(30)));
            }

            return Ok(searchList);
        }


        [HttpPost("applyDiscountCode")]
        public async Task<IActionResult> ApplyDiscountCode(ApplyDiscountCodeCommand applyDiscountCodeCommand)
        {
            var result = await Mediator.Send(applyDiscountCodeCommand);

            return result.ApiResult;
        }


        [HttpDelete("/removeDiscountCode/{id}")]
        public async Task<IActionResult> RemoveDiscountCode(long id)
        {
            var result = await Mediator.Send(new GetOrderQuery { Id = id });

            return result.ApiResult;
        }


        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(CreateShoppingCartViewModel shoppingCartViewModel)
        {
            var shoppingCart = _shoppingCartService.GetCustomerShoppingCartViewModelList();

            if (_shoppingCartService.IsProductExistInShopCart(shoppingCartViewModel.ProductVariantId))
                shoppingCart = _shoppingCartService.UpdateShoppingCartCountFromCookie(shoppingCart, shoppingCartViewModel.ProductVariantId, shoppingCartViewModel.Count);

            else
                shoppingCart = await _shoppingCartService.CreateShoppingCartCookie(shoppingCart, shoppingCartViewModel);

            return Ok(BasketViewModel.GetBasketViewModel(shoppingCart.Count, shoppingCart.Sum(x => x.Count * x.Price)));

        }


        [HttpDelete("DeleteFromCart/{Id}")]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var shoppingCart = _shoppingCartService.GetCustomerShoppingCartViewModelList();

            shoppingCart = _shoppingCartService.DeleteShoppingCartFromCookie(shoppingCart, id);

            if (User.Identity.IsAuthenticated)
                await Mediator.Send(new DeleteUserOrderCommand { ProductVariantId = id });

            return Ok(BasketViewModel.GetBasketViewModel(shoppingCart.Count, shoppingCart.Sum(x => x.Count * x.Price)));
        }


        [HttpPost("AddComment")]
        public async Task<IActionResult> CreateComment(CreateCommentCommand createCommentCommand)
        {

            var result = await Mediator.Send(createCommentCommand);

            return result.ApiResult;
        }

    }
}