using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Auth
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly ICmsDbContext _context;
        public RegisterCommandValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage(ResponseMessage.NameIsRequired).MinimumLength(3).WithMessage(ResponseMessage.MinLengthName);

            RuleFor(dto => dto.Family).
                NotEmpty()
                .WithMessage(ResponseMessage.FamilyIsRequired).MinimumLength(3).WithMessage(ResponseMessage.MinLengthFamily);

            RuleFor(dto => dto.Email).NotEmpty().WithMessage(ResponseMessage.EmptyEmail)
                .EmailAddress().WithMessage(ResponseMessage.InvalidEmailAddress);

            RuleFor(dto => dto.Password).NotEmpty().WithMessage(ResponseMessage.InvalidPassword)
                .MinimumLength(6).WithMessage(ResponseMessage.MaxLengthPassword);

            RuleFor(dto => dto).MustAsync(ValidEmailAddress).WithMessage(ResponseMessage.EmailIsExist);
        }

        private async Task<bool> ValidEmailAddress(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(
                x => x.Email == registerCommand.Email && x.Status != Status.Delete, cancellationToken))
                return false;

            return true;
        }
    }
}