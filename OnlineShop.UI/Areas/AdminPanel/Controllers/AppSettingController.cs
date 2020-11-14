using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.AppSetting.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class AppSettingController : BaseAdminController
    {
        [HttpGet]
        public async Task<IActionResult> AppSettings()
        {
            var result = await Mediator.Send(new GetAppSettingQuery());

            return View(result);
        }
    }
}