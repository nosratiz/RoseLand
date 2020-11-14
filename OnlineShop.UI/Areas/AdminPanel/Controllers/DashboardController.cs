using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dashboard.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{

    public class DashboardController : BaseAdminController
    {
        [HttpGet]
        public async Task<IActionResult> Index() => View(await Mediator.Send(new GetDashboardQuery()));


    }
}