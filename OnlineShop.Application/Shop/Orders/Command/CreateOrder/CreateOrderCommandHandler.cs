using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Cart;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly ICmsDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(ICmsDbContext context, IShoppingCartService shoppingCartService, ICurrentUserService currentUserService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = _shoppingCartService.GetCustomerShoppingCartViewModelList();

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in shoppingCart)
            {
                var productVariant = await _context.ProductVariants.SingleOrDefaultAsync(x => x.Id == item.ProductVariantId, cancellationToken);

                if (productVariant is null)
                    return Result.Failed(new ApiMessage(ResponseMessage.ProductNotfound));

                orderItems.Add(new OrderItem
                {
                    Count = item.Count,
                    CreateDate = DateTime.Now,
                    Price = productVariant.DiscountPrice.HasValue && productVariant.DiscountPrice.Value > 0 ? productVariant.DiscountPrice.Value : productVariant.Price,
                    UserId = int.Parse(_currentUserService.UserId),
                    ProductVariantId = item.ProductVariantId,

                });

            }

            var existOrder = await _context.Orders.Include(x => x.OrderItems).SingleOrDefaultAsync(x =>
                  !x.IsDeleted && x.OrderStatus == OrderStatus.InBasket &&
                  x.UserAddress.UserId == int.Parse(_currentUserService.UserId), cancellationToken);

            Order order;

            if (existOrder is null)
            {
                order = new Order
                {
                    CreateDate = DateTime.Now,
                    DeliveryDate = request.DeliveryDate,
                    FinalAmount = orderItems.Sum(x => x.Count * x.Price),
                    OrderStatus = OrderStatus.InBasket,
                    UserAddressId = request.UserAddressId,
                    DeliverPeriodTime = request.DeliverPeriodTime,
                    OrderNumber = $"RL-{new Random().Next(10000, 99999)}",
                    ShipmentPrice = 0,
                    DiscountPrice = 0,
                };

                await _context.Orders.AddAsync(order, cancellationToken);

            }

            else
            {
                _context.OrderItems.RemoveRange(existOrder.OrderItems);

                existOrder.UserAddressId = request.UserAddressId;
                existOrder.DeliverPeriodTime = request.DeliverPeriodTime;
                existOrder.DeliveryDate = request.DeliveryDate;
                existOrder.FinalAmount = orderItems.Sum(x => x.Count * x.Price);

                order = existOrder;

            }


            orderItems.ForEach(x => { x.Order = order; });

            await _context.OrderItems.AddRangeAsync(orderItems, cancellationToken);


            await _context.SaveAsync(cancellationToken);


            return Result.SuccessFull(new OkObjectResult(new ApiMessage(ResponseMessage.UpdateSuccessfully)));

        }
    }
}