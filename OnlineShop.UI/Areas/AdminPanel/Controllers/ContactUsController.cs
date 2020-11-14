using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.General.ContactUs.Command;
using OnlineShop.Application.General.ContactUs.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class ContactUsController : BaseAdminController
    {
        public async Task<IActionResult> ContactUsList(PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetContactUsListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search
            }));


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactUs(long id)
            => View(await Mediator.Send(new GetContactUsQuery { Id = id }));


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactUs(long id)
        {
            var result = await Mediator.Send(new DeleteContactUsCommand { Id = id });

            return result.ApiResult;
        }
    }
}