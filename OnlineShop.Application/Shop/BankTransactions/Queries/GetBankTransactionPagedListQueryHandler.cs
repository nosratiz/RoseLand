using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.BankTransactions.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.BankTransactions.Queries
{
    public class GetBankTransactionPagedListQueryHandler : PagingService<BankTransaction>, IRequestHandler<GetBankTransactionPagedListQuery, Result<PagedList<BankTransactionDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;

        public GetBankTransactionPagedListQueryHandler(ICmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<BankTransactionDto>>> Handle(GetBankTransactionPagedListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<BankTransaction> bankTransaction = _context.BankTransactions.Include(x => x.Order);

            if (!string.IsNullOrWhiteSpace(request.Search))
                bankTransaction = bankTransaction.Where(x => x.Order.OrderNumber == request.Search);

            if (request.RefId.HasValue)
                bankTransaction = bankTransaction.Where(x => x.RefId == request.RefId);

            var bankTransactionList = await GetPagedAsync(request.Page, request.Limit, bankTransaction);

            return Result<PagedList<BankTransactionDto>>.SuccessFull(bankTransactionList.MapTo<BankTransactionDto>(_mapper), request); ;
        }
    }
}