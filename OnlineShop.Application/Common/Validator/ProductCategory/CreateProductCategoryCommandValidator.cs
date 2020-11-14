using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.ProductCategories.Command.CreateCategory;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.ProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        private readonly ICmsDbContext _context;

        public CreateProductCategoryCommandValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name).NotEmpty().WithMessage(ResponseMessage.NameIsRequired);

            RuleFor(dto => dto).MustAsync(ValidParent).WithMessage(ResponseMessage.CategoryNotFound);
        }

        private async Task<bool> ValidParent(CreateProductCategoryCommand createProductCategory, CancellationToken cancellationToken)
        {
            if (createProductCategory.ParentId.HasValue)
                if (!await _context.ProductCategories.AnyAsync(x => !x.IsDeleted && x.Id == createProductCategory.ParentId.Value, cancellationToken))
                    return false;

            return true;
        }
    }
}