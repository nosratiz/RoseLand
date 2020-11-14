using System;
using MediatR;
using OnlineShop.Application.Shop.BankTransactions.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.BankTransactions.Queries
{
    public class GetBankTransactionQuery : IRequest<Result<BankTransactionDto>>
    {
        public Guid Id { get; set; }
    }
}