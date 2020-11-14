using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Authentication.ModelDto;
using OnlineShop.Application.Users.Queries;
using OnlineShop.UI.Core.Extensions;

namespace OnlineShop.UI.ViewComponents
{
    public class ProfileSideBarComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ProfileSideBarComponent(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IViewComponentResult> InvokeAsync(string url)
            => await Task.FromResult((IViewComponentResult)View("ProfileBox", ProfileSideBarViewModel.GetProfileSideBarViewModel(await _mediator.Send(new GetUserQuery
                        {
                            Id = UserClaimsPrincipal.GetUserId()
                        }), url)));

    }
}