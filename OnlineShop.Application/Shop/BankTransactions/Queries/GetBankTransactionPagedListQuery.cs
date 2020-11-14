using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.BankTransactions.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;


namespace OnlineShop.Application.Shop.BankTransactions.Queries
{
    public class GetBankTransactionPagedListQuery : BankTransactionFilterDto, IRequest<Result<PagedList<BankTransactionDto>>>
    {

    }
}