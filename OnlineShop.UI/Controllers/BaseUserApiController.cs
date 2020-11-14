using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.UI.Core;

namespace OnlineShop.UI.Controllers {
    [Route ("[Controller]")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    [Authorize]
    public class BaseUserApiController : Controller {
        public AppUserLogin CurrentUser => new AppUserLogin (User);

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator> ();
    }
}