using System.Collections.Generic;
using MediatR;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<Result<ProductDto>>
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public string Tag { get; set; }
        public bool IsSpecial { get; set; }
        public List<string> Galleries { get; set; }
    }
}