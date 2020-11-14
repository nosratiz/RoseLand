using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductVariants.Command.CreateCommand
{
    public class CreateProductVariantCommand : IRequest<Result<ProductVariantDto>>
    {
        public int ProductId { get; set; }
        public long Price { get; set; }
        public long? DiscountPrice { get; set; }
        public int Count { get; set; }
        public BoxType BoxType { get; set; }
        public string Description { get; set; }

    }
}