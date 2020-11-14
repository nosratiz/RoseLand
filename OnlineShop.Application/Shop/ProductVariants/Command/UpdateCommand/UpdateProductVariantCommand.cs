using MediatR;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.Shop.ProductVariants.Command.UpdateCommand
{
    public class UpdateProductVariantCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public long Price { get; set; }
        public long? DiscountPrice { get; set; }
        public int Count { get; set; }
        public BoxType BoxType { get; set; }
        public string Description { get; set; }
    }
}