using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Application.General.Menu.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class MenuController : BaseAdminController
    {

        public async Task<IActionResult> MenuList(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetMenuListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search
            }));


        [HttpGet("addMenu")]
        public async Task<IActionResult> AddMenu()
        {
            var result = await Mediator.Send(new GetMenuListQuery { Page = 1, Limit = 100 });

            return View(result.Data.Items);
        }


        [HttpGet("editMenu")]
        public async Task<IActionResult> EditMenu(int id)
        {
            var result = await Mediator.Send(new GetMenuQuery { Id = id });

            var menuList = await Mediator.Send(new GetMenuListQuery { Page = 1, Limit = 100 });

            return View(UpdateMenuViewModel.GetUpdateMenuViewModel(result, menuList.Data.Items));
        }


    }
}