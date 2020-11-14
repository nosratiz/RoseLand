using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.Cart.ModelDto;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Cart
{
    public class CreateShoppingCartViewModelValidator : AbstractValidator<CreateShoppingCartViewModel>
    {
        private readonly ICmsDbContext _context;
        public CreateShoppingCartViewModelValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Count).NotEmpty().WithMessage(ResponseMessage.CountIsRequired)
                .GreaterThan(0).WithMessage(ResponseMessage.InvalidCount);

            RuleFor(dto => dto.ProductVariantId).NotEmpty();

            RuleFor(dto => dto).MustAsync(ValidVariant).WithMessage(ResponseMessage.ProductNotfound);
        }

        private async Task<bool> ValidVariant(CreateShoppingCartViewModel createShoppingCartView,
            CancellationToken cancellationToken)
        {
            if (!await _context.ProductVariants.AnyAsync(x => x.Id == createShoppingCartView.ProductVariantId, cancellationToken))
                return false;
            return true;
        }
    }
}