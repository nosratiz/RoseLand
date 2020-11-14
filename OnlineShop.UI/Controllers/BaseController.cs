using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.UI.Core;

namespace OnlineShop.UI.Controllers {
    public class BaseController : Controller {
        public AppUserLogin CurrentUser => new AppUserLogin (User);

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator> ();
    }
}