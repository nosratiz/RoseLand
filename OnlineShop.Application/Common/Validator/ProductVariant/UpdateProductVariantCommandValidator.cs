using FluentValidation;
using OnlineShop.Application.Shop.ProductVariants.Command.UpdateCommand;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.ProductVariant
{
    public class UpdateProductVariantCommandValidator : AbstractValidator<UpdateProductVariantCommand>
    {
        public UpdateProductVariantCommandValidator()
        {
            RuleFor(dto => dto.Price).NotEmpty().WithMessage(ResponseMessage.PriceIsRequired);

            RuleFor(dto => dto.Count).NotEmpty().WithMessage(ResponseMessage.CountIsRequired);

        }
    }
}