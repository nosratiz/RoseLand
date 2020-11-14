using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.AppSetting.Command.UpdateSetting;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class AppSettingController : BaseApiController
    {

        public async Task<IActionResult> UpdateAppSetting(UpdateAppSettingCommand updateAppSetting)
        {
            var result = await Mediator.Send(updateAppSetting);

            return result.ApiResult;
        }
    }
}