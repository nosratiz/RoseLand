using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Shop.DiscountCodes.Command.ApplyDiscountCode;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.Common.Validator.DiscountCode
{
    public class ApplyDiscountCodeValidator : AbstractValidator<ApplyDiscountCodeCommand>
    {
        private readonly ICmsDbContext _context;

        public ApplyDiscountCodeValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Code).NotEmpty().WithMessage(ResponseMessage.EmptyCode);


            RuleFor(dto => dto).MustAsync(ValidCode).WithMessage(ResponseMessage.discountCodeNotValid);
        }



        private async Task<bool> ValidCode(ApplyDiscountCodeCommand applyDiscountCodeCommand,
            CancellationToken cancellationToken)
        {
            var discountCode = await _context.DiscountCodes.SingleOrDefaultAsync(
                x => x.Code == applyDiscountCodeCommand.Code && x.IsDeleted == false, cancellationToken);

            if (discountCode is null)
                return false;

            if (discountCode.Count <= 0)
                return false;

            if (discountCode.EndDateTime <= DateTime.Now)
                return false;

            return true;
        }
    }
}