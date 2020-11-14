using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.BankTransactions.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.BankTransactions.Queries
{
    public class GetBankTransactionQueryHandler : IRequestHandler<GetBankTransactionQuery, Result<BankTransactionDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBankTransactionQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<BankTransactionDto>> Handle(GetBankTransactionQuery request, CancellationToken cancellationToken)
        {
            var bankTransaction =
                await _context.BankTransactions.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (bankTransaction is null)
                return Result<BankTransactionDto>.Failed(new NotFoundObjectResult(new ApiMessage(ResponseMessage.TransactionNotFound)));

            return Result<BankTransactionDto>.SuccessFull(_mapper.Map<BankTransactionDto>(bankTransaction));
        }
    }
}