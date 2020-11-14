using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.ProductCategories.Queries;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Application.Shop.Products.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class ProductController : BaseAdminController
    {
        [HttpGet]
        public async Task<IActionResult> List(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetProductPagedListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search
            }));



        [HttpGet("add")]
        public async Task<IActionResult> Add()
        {
            var productCategory = await Mediator.Send(new GetProductCategoryPagedListQuery { Limit = 100, Page = 1 }).ConfigureAwait(false);
         
            return View(productCategory.Data.Items);
        }



        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var productCategory = await Mediator.Send(new GetProductCategoryPagedListQuery { Limit = 100, Page = 1 }).ConfigureAwait(false);

            var product = await Mediator.Send(new GetProductQuery { Id = id });

            return View(UpdateProductViewModel.GetUpdateProductViewModel(product, productCategory.Data.Items));
        }



    }
}