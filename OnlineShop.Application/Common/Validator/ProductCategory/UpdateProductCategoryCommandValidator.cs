using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductCategories.Command.UpdateCategory;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.ProductCategory
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        private readonly ICmsDbContext _context;

        public UpdateProductCategoryCommandValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto).MustAsync(ValidParent).WithMessage(ResponseMessage.CategoryNotFound);
        }

        private async Task<bool> ValidParent(UpdateProductCategoryCommand updateProductCategory, CancellationToken cancellationToken)
        {

            if (updateProductCategory.ParentId.HasValue)
                if (!await _context.ProductCategories.AnyAsync(x => !x.IsDeleted && x.Id == updateProductCategory.ParentId.Value, cancellationToken))
                    return false;

            return true;
        }



    }
}