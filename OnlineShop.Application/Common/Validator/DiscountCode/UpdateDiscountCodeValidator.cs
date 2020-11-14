using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.DiscountCodes.Command.CreateDiscountCode;
using OnlineShop.Application.Shop.DiscountCodes.Command.UpdateDiscountCode;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.DiscountCode
{
    public class UpdateDiscountCodeValidator : AbstractValidator<UpdateDiscountCodeCommand>
    {
        private readonly ICmsDbContext _context;

        public UpdateDiscountCodeValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Code).NotEmpty().WithMessage(ResponseMessage.EmptyCode);

            RuleFor(dto => dto.Count).NotEmpty().WithMessage(ResponseMessage.CountIsRequired);

            RuleFor(dto => dto.Price).NotEmpty().WithMessage(ResponseMessage.AmountIsRequired);

            RuleFor(dto => dto).Must(ValidAmount).WithMessage(ResponseMessage.InvalidPercentage)
                .Must(ValidDateTime).WithMessage(ResponseMessage.InvalidDateTime)
                .MustAsync(ValidCod).WithMessage(ResponseMessage.CodeExist);
        }

        private bool ValidDateTime(UpdateDiscountCodeCommand updateDiscountCode)
        {
            if (!string.IsNullOrWhiteSpace(updateDiscountCode.StartDate) || !string.IsNullOrWhiteSpace(updateDiscountCode.EndDateTime))
            {
                try
                {
                    var startDate = DateTimeConvertor.ToGregorianDateTime(updateDiscountCode.StartDate);
                    var endDate = DateTimeConvertor.ToGregorianDateTime(updateDiscountCode.EndDateTime);

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

        private bool ValidAmount(UpdateDiscountCodeCommand updateDiscountCode)
        {
            if (updateDiscountCode.DiscountType == DiscountType.Percentage && (updateDiscountCode.Price <= 0 || updateDiscountCode.Price > 100))
                return false;

            return true;

        }

        private async Task<bool> ValidCod(UpdateDiscountCodeCommand updateDiscountCode, CancellationToken cancellationToken)
            => !await _context.DiscountCodes.AnyAsync(x => !x.IsDeleted && x.Code == updateDiscountCode.Code && x.Id != updateDiscountCode.Id, cancellationToken);

    }
}