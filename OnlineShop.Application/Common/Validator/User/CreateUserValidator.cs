using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Users.Command.CreateUser;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly ICmsDbContext _context;

        public CreateUserValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.PhoneNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ResponseMessage.InvalidMobile)
                .MaximumLength(11).WithMessage(ResponseMessage.InvalidMobile);

            RuleFor(dto => dto.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .EmailAddress().WithMessage(ResponseMessage.InvalidEmailAddress)
                .MaximumLength(32).WithMessage(ResponseMessage.InvalidEmailAddress);

            RuleFor(dto => dto.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ResponseMessage.InvalidNameOrFamily)
                .MaximumLength(16).WithMessage(ResponseMessage.InvalidNameOrFamily);

            RuleFor(dto => dto.Family)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ResponseMessage.InvalidNameOrFamily)
                .MaximumLength(16).WithMessage(ResponseMessage.InvalidNameOrFamily);

            RuleFor(dto => dto).Cascade(CascadeMode.StopOnFirstFailure)
                .MustAsync(ValidEmail).WithMessage(ResponseMessage.EmailAddressAlreadyExist)
                .MustAsync(ValidMobile).WithMessage(ResponseMessage.MobileAlreadyExist);

        }

        private async Task<bool> ValidEmail(CreateUserCommand createUser, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(createUser.Email))
                return true;

            if (await _context.Users.AnyAsync(x => x.Email == createUser.Email, cancellationToken))
                return false;

            return true;

        }

        private async Task<bool> ValidMobile(CreateUserCommand createUserDto, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(x => x.PhoneNumber == createUserDto.PhoneNumber, cancellationToken))
                return false;

            return true;

        }

    }
}