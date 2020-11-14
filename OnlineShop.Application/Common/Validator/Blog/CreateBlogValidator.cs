using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Blog.Command.CreateBlog;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Blog
{
    public class CreateBlogValidator : AbstractValidator<CreateBlogCommand>
    {
        private readonly ICmsDbContext _context;

        public CreateBlogValidator(ICmsDbContext context)
        {
            _context = context;

            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage(ResponseMessage.TitleIsRequired);

            RuleFor(dto => dto.LongDescription)
                .NotEmpty().WithMessage(ResponseMessage.ContentIsRequired);



            RuleFor(dto => dto).MustAsync(ValidSlug)
                .WithMessage(ResponseMessage.SlugExist).MustAsync(ValidCategory)
                .WithMessage(ResponseMessage.BlogCategoryNotFound);
        }

        private async Task<bool> ValidSlug(CreateBlogCommand createBlogCommand, CancellationToken cancellationToken)
        {

            if (!string.IsNullOrWhiteSpace(createBlogCommand.Slug))
                if (await _context.Blogs.AnyAsync(x => x.Slug == createBlogCommand.Slug, cancellationToken))
                    return false;

            return true;

        }

        private async Task<bool> ValidCategory(CreateBlogCommand createBlogCommand, CancellationToken cancellationToken)
        {
            if (!await _context.BlogCategories.AnyAsync(x => x.Id == createBlogCommand.CategoryId,cancellationToken))
                return false;

            return true;
        }



        private bool ValidContentType(CreateBlogCommand createBlogCommand)
        {
            Type enumType = createBlogCommand.ContentType.GetType();

            bool valid = Enum.IsDefined(enumType, createBlogCommand.ContentType);

            return valid;
        }

    }
}