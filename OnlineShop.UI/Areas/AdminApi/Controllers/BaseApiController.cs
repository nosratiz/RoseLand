using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.UI.Core;
using OnlineShop.UI.Filter;

namespace OnlineShop.UI.Areas.AdminApi.Controllers
{
    [Area("AdminApi")]
    [Route("[Area]/[Controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [ServiceFilter(typeof(AdminAuthorization))]
    public class BaseApiController : Controller
    {

        public AppUserLogin CurrentUser => new AppUserLogin(User);

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}