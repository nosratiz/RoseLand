using MediatR;
using OnlineShop.Application.Common.General;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Shop.ProductCategories.Queries
{
    public class GetProductCategoryPagedListQuery : PagingOptions, IRequest<Result<PagedList<ProductCategoryDto>>>
    {

    }
}