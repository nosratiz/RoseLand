using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.BankTransactions.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.BankTransactions.Queries
{
    public class GetUserBankTransactionPagedListQuery : PagingOptions, IRequest<Result<PagedList<BankTransactionDto>>>
    {
    }


    public class GetUserBankTransactionPagedListQueryHandler : PagingService<BankTransaction>, IRequestHandler<GetUserBankTransactionPagedListQuery, Result<PagedList<BankTransactionDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetUserBankTransactionPagedListQueryHandler(ICmsDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Result<PagedList<BankTransactionDto>>> Handle(GetUserBankTransactionPagedListQuery request,
            CancellationToken cancellationToken)
        {
            var bankTransactions = _context.BankTransactions.Include(x=>x.Order).Where(x =>
                x.RefId.HasValue && x.Order.UserAddress.UserId == int.Parse(_currentUserService.UserId));


            var bankTransactionPagedList = await GetPagedAsync(request.Page, request.Limit, bankTransactions);

            return Result<PagedList<BankTransactionDto>>.SuccessFull(bankTransactionPagedList.MapTo<BankTransactionDto>(_mapper));
        }
    }
}