using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Application.Shop.ProductVariants.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class ProductVariantController : BaseAdminController
    {

        [HttpGet("{productId}/List")]
        public async Task<IActionResult> List(int productId, [FromQuery]PagingOptions pagingOptions)
            => View(ProductVariantListViewModel.GetProductVariantViewModel(
                await Mediator.Send(new GetProductVariantPagedListQuery
                {
                    ProductId = productId,
                    Limit = pagingOptions.Limit,
                    Page = pagingOptions.Page,
                    Search = pagingOptions.Search

                }), productId));


        [HttpGet("add")]
        public IActionResult Add(int productId) => View(productId);



        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await Mediator.Send(new GetProductVariantQuery { Id = id });

            return View(ProductVariantViewModel.GetProductVariantViewModel(result,id));
        }
    }
}