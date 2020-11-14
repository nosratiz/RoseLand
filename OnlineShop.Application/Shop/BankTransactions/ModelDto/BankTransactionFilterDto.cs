using OnlineShop.Application.Common.General;

namespace OnlineShop.Application.Shop.BankTransactions.ModelDto
{
    public class BankTransactionFilterDto : PagingOptions
    {
        public long? RefId { get; set; }


    }
}