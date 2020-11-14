using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.DiscountCodes.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class DiscountCodeController : BaseAdminController
    {

        [HttpGet]
        public async Task<IActionResult> List(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetDiscountCodePagedListQuery
            {
                Page = pagingOptions.Page,
                Limit = pagingOptions.Limit,
                Search = pagingOptions.Search
            }));



        [HttpGet("addDiscountCode")]
        public IActionResult Add() => View();



        [HttpGet("editDiscountCode")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await Mediator.Send(new GetDiscountCodeQuery { Id = id });

            return View(result);
        }

    }
}

