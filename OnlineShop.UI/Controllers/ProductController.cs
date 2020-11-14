using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Application.Shop.Products.Queries;

namespace OnlineShop.UI.Controllers
{
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> ProductList([FromQuery] AdvanceFilterProduct advanceFilterProduct)
        => View(
             await Mediator.Send(new GetAdvanceProductPagedListQuery
             {
                 Page = advanceFilterProduct.Page,
                 Limit = advanceFilterProduct.Limit,
                 Search = advanceFilterProduct.Search,
                 SortOrder = advanceFilterProduct.SortOrder,
                 Desc = advanceFilterProduct.Desc,
                 CategoryId = advanceFilterProduct.CategoryId,
                 MinPrice = advanceFilterProduct.MinPrice,
                 MaxPrice = advanceFilterProduct.MaxPrice
             }));



        [HttpGet("{slug}")]
        public async Task<IActionResult> ProductDetail(string slug) => View(await Mediator.Send(new GetProductBySlugQuery {Slug = slug}));



    }
}
