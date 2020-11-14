using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.DiscountCodes.Command.CreateDiscountCode;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.DiscountCode
{
    public class CreateDiscountCodeValidator : AbstractValidator<CreateDiscountCodeCommand>
    {
        private readonly ICmsDbContext _context;
        public CreateDiscountCodeValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Code).NotEmpty().WithMessage(ResponseMessage.EmptyCode);

            RuleFor(dto => dto.Count).NotEmpty().WithMessage(ResponseMessage.CountIsRequired);

            RuleFor(dto => dto.Price).NotEmpty().WithMessage(ResponseMessage.AmountIsRequired);

            RuleFor(dto => dto).Must(ValidAmount).WithMessage(ResponseMessage.InvalidPercentage)
                .Must(ValidDateTime).WithMessage(ResponseMessage.InvalidDateTime)
                .MustAsync(ValidCod).WithMessage(ResponseMessage.CodeExist);
        }


        private bool ValidDateTime(CreateDiscountCodeCommand createDiscountCode)
        {
            if (!string.IsNullOrWhiteSpace(createDiscountCode.StartDate) || !string.IsNullOrWhiteSpace(createDiscountCode.EndDateTime))
            {
                try
                {
                    var startDate = DateTimeConvertor.ToGregorianDateTime(createDiscountCode.StartDate);
                    var endDate = DateTimeConvertor.ToGregorianDateTime(createDiscountCode.EndDateTime);

                    if (startDate > endDate)
                        return false;

                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidAmount(CreateDiscountCodeCommand createDiscountCodeCommand)
        {
            if (createDiscountCodeCommand.DiscountType == DiscountType.Percentage && (createDiscountCodeCommand.Price <= 0 || createDiscountCodeCommand.Price > 100))
                return false;

            return true;

        }

        private async Task<bool> ValidCod(CreateDiscountCodeCommand createDiscountCodeCommand, CancellationToken cancellationToken)
        => !await _context.DiscountCodes.AnyAsync(x => !x.IsDeleted && x.Code == createDiscountCodeCommand.Code, cancellationToken);

    }
}