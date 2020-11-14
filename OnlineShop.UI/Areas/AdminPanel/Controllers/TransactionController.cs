using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.BankTransactions.Queries;

namespace OnlineShop.UI.Areas.AdminPanel.Controllers
{
    public class TransactionController : BaseAdminController
    {

        [HttpGet]
        public async Task<IActionResult> TransactionList([FromQuery] PagingOptions pagingOptions)
            => View(await Mediator.Send(new GetBankTransactionPagedListQuery
            {
                Limit = pagingOptions.Limit,
                Page = pagingOptions.Page,
                Search = pagingOptions.Search
            }));


    }
}