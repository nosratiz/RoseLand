using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.UI.Core;
using OnlineShop.UI.Filter;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Route("[Area]/[Controller]")]
    [ServiceFilter(typeof(AdminAuthorization))]
    public class BaseAdminController : Controller
    {
        public AppUserLogin CurrentUser => new AppUserLogin(User);

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}