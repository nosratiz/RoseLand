using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Application.Shop.ProductCategories.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class ProductCategoryController : BaseAdminController
    {

        [HttpGet]
        public async Task<IActionResult> ProductCategoryList(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetProductCategoryPagedListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search
            }));



        [HttpGet("addCategory")]
        public async Task<IActionResult> AddProductCategory()
        {
            var productCategory = await Mediator.Send(new GetProductCategoryPagedListQuery { Page = 1, Limit = 100 });
         
            return View(productCategory.Data.Items);
        }



        [HttpGet("editCategory")]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await Mediator.Send(new GetProductCategoryQuery { Id = id });
     
            var productCategories = await Mediator.Send(new GetProductCategoryPagedListQuery { Page = 1, Limit = 100 });

            return View(UpdateProductCategoryViewModel.GetCategoryViewModel(productCategories.Data.Items, category));
        }

    }
}