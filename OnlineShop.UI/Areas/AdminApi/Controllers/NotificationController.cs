using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.Notifications.Queries;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    public class NotificationController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetNotification([FromQuery] PagingOptions pagingOptions)
        {
            var result = await Mediator.Send(new GetNotificationListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page
            });

            return result.ApiResult;
        }
    }
}
