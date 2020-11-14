using System.Security;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class NavBarController : BaseAdminController
    {
        public ActionResult HeaderMenu() => PartialView();
        

        public ActionResult SideBarMenu() => PartialView();
        
    }
}