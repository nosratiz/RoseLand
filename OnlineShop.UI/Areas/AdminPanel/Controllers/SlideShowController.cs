using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.SlideShow.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class SlideShowController : BaseAdminController
    {

        [HttpGet]
        public async Task<IActionResult> List(PagingOptions pagingOptions) => View(await Mediator.Send(new GetSlideShowPagedListQuery
        {
            Page = pagingOptions.Page,
            Limit = pagingOptions.Limit,
            Search = pagingOptions.Search
        }));




        [HttpGet("add")]
        public IActionResult Add() => View();



        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await Mediator.Send(new GetSlideShowQuery {Id = id});

            return View(result);
        }
    }
}