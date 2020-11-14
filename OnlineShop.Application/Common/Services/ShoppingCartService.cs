using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Application.Shop.Cart.ModelDto;

namespace OnlineShop.Application.Common.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICmsDbContext _context;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, ICmsDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public List<CreateShoppingCartViewModel> GetCustomerShoppingCartViewModelList()
        {
            return IsShoppingCartInfoExist()
                ? JsonConvert.DeserializeObject<List<CreateShoppingCartViewModel>>(_httpContextAccessor.HttpContext.Request.Cookies["CSC"])
                : new List<CreateShoppingCartViewModel>();
        }

        public List<CreateShoppingCartViewModel> UpdateShoppingCartCountFromCookie(List<CreateShoppingCartViewModel> createCustomerShoppingCartView, int productVariantId, int count)
        {
            if (!IsShoppingCartInfoExist())
                return null;

            CreateShoppingCartViewModel customerShoppingCartViewModel = createCustomerShoppingCartView.Find(p => p.ProductVariantId == productVariantId);

            if (customerShoppingCartViewModel != null)
                customerShoppingCartViewModel.Count = count;

            ExpireShoppingCartCookie();

            CreateCookie(createCustomerShoppingCartView);

            return createCustomerShoppingCartView;
        }

        public List<CreateShoppingCartViewModel> DeleteShoppingCartFromCookie(List<CreateShoppingCartViewModel> createCustomerShoppingCartView, int productVariantId)
        {
            if (!IsShoppingCartInfoExist())
                return null;

            CreateShoppingCartViewModel customerShoppingCartViewModel = createCustomerShoppingCartView.Find(p => p.ProductVariantId == productVariantId);

            if (customerShoppingCartViewModel != null)
                createCustomerShoppingCartView.Remove(customerShoppingCartViewModel);

            ExpireShoppingCartCookie();

            if (createCustomerShoppingCartView.Any())
                CreateCookie(createCustomerShoppingCartView);

            return createCustomerShoppingCartView;
        }

        public List<CreateShoppingCartViewModel> DeleteShoppingCartFromCookie(int productVariantId)
        {
            if (!IsShoppingCartInfoExist())
                return null;

            List<CreateShoppingCartViewModel> currentShoppingCartList = JsonConvert.DeserializeObject<List<CreateShoppingCartViewModel>>(_httpContextAccessor.HttpContext.Request.Cookies["CSC"]);

            CreateShoppingCartViewModel customerShoppingCartViewModel = currentShoppingCartList.Find(p => p.ProductVariantId == productVariantId);

            if (customerShoppingCartViewModel != null)
                currentShoppingCartList.Remove(customerShoppingCartViewModel);

            ExpireShoppingCartCookie();

            if (currentShoppingCartList.Any())
                CreateCookie(currentShoppingCartList);

            return currentShoppingCartList;
        }

        public List<CreateShoppingCartViewModel> DeleteShoppingCartCookie()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append("CSC", _httpContextAccessor.HttpContext.Request.Cookies["CSC"], new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            });
            return new List<CreateShoppingCartViewModel>();
        }
        public async Task<List<CreateShoppingCartViewModel>> CreateShoppingCartCookie(List<CreateShoppingCartViewModel> currentShoppingCartList, CreateShoppingCartViewModel shoppingCartViewModel)
        {
            var productVariant =
                await _context.ProductVariants.FirstOrDefaultAsync(x => x.Id == shoppingCartViewModel.ProductVariantId);

            if (IsShoppingCartInfoExist())
            {

                var shop = currentShoppingCartList.Find(x => x.ProductVariantId == shoppingCartViewModel.ProductVariantId);

                if (shop != null)
                {
                    shop.Count += shoppingCartViewModel.Count;

                    currentShoppingCartList.Add(shoppingCartViewModel);

                    ExpireShoppingCartCookie();

                    CreateCookie(currentShoppingCartList);
                }
                else
                {
                    shoppingCartViewModel.Price = productVariant.DiscountPrice ?? productVariant.Price;
                    currentShoppingCartList.Add(shoppingCartViewModel);

                    ExpireShoppingCartCookie();

                    CreateCookie(currentShoppingCartList);
                }
            }

            else
            {
                shoppingCartViewModel.Price = productVariant.DiscountPrice ?? productVariant.Price;
                currentShoppingCartList =
                      new List<CreateShoppingCartViewModel>
                      {
                        shoppingCartViewModel
                      };

                CreateCookie(currentShoppingCartList);
            }

            return currentShoppingCartList;

        }


        public bool IsProductExistInShopCart(int productVariantId)
        {
            if (IsShoppingCartInfoExist())
                return JsonConvert.DeserializeObject<List<CreateShoppingCartViewModel>>(_httpContextAccessor.HttpContext.Request.Cookies["CSC"])
                    .Any(sc => sc.ProductVariantId == productVariantId);

            return false;
        }

        public bool IsShoppingCartInfoExist()
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies["CSC"] == null)
                return false;

            try
            {
                JsonConvert.DeserializeObject<List<CreateShoppingCartViewModel>>(_httpContextAccessor.HttpContext.Request.Cookies["CSC"]);
                return true;
            }
            catch
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append("CSC", _httpContextAccessor.HttpContext.Request.Cookies["CSC"], new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                });

                return false;
            }
        }

        public int CustomerShoppingCartCookieCount()
        {
            if (string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.Request.Cookies["CSC"]))
                return 0;

            var shoppingCart = JsonConvert.DeserializeObject<List<CreateShoppingCartViewModel>>(_httpContextAccessor.HttpContext.Request.Cookies["CSC"]);

            if (shoppingCart is null)
                return 0;

            return shoppingCart.Count;
        }

        public void ExpireShoppingCartCookie() => _httpContextAccessor.HttpContext.Response.Cookies.Delete("CSC");

        private void CreateCookie(List<CreateShoppingCartViewModel> shoppingCart)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append("CSC", JsonConvert.SerializeObject(shoppingCart), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true
            });
        }
    }
}