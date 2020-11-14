using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.Menu.Command.CreateMenu;
using OnlineShop.Application.General.Menu.Command.DeleteMenu;
using OnlineShop.Application.General.Menu.Command.UpdateMenu;
using OnlineShop.Application.General.Menu.ModelDto;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class MenuController : BaseApiController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteMenuCommand { Id = id });

            return result.ApiResult;
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu(CreateMenuCommand createMenuCommand)
        {
            var result = await Mediator.Send(createMenuCommand);

            return result.ApiResult;
        }

        [HttpPut]
        public async Task<IActionResult> EditMenu(UpdateMenuCommand updateMenuViewModel)
        {
            var result = await Mediator.Send(updateMenuViewModel);

            return result.ApiResult;
        }
    }
}