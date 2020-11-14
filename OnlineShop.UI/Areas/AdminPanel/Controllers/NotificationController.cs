using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.General.Notifications.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class NotificationController : BaseAdminController
    {

        public async Task<IActionResult> List()
        {
            var result = await Mediator.Send(new GetNotificationListQuery { Page = 1, Limit = 100 });

            return View(result.Data);
        }
    }
}
