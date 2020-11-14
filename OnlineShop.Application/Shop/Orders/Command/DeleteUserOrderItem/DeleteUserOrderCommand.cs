using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;

namespace OnlineShop.Application.Shop.Orders.Command.DeleteUserOrderItem
{
    public class DeleteUserOrderCommand : IRequest
    {
        public int ProductVariantId { get; set; }
    }


    public class DeleteUserOrderCommandHandler : IRequestHandler<DeleteUserOrderCommand>
    {
        private readonly ICmsDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserOrderCommandHandler(ICmsDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteUserOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItems = await _context.OrderItems.FirstOrDefaultAsync(x => x.ProductVariantId == request.ProductVariantId && x.UserId == int.Parse(_currentUserService.UserId), cancellationToken);


            if (orderItems != null)
            {
                _context.OrderItems.Remove(orderItems);
                await _context.SaveAsync(cancellationToken);
            }

            return Unit.Value;

        }
    }
}