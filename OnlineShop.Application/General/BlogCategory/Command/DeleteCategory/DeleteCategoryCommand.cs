using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.BlogCategory.Command.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}