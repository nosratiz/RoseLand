using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.General.Blog.Command.UpdateBlog;
using OnlineShop.Common.Helper;

namespace OnlineShop.Application.Common.Validator.Blog
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogCommand>
    {
        private readonly ICmsDbContext _context;

        public UpdateBlogValidator(ICmsDbContext context)
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

        private async Task<bool> ValidSlug(UpdateBlogCommand updateBlogCommand, CancellationToken cancellationToken)
        {
            if (await _context.Blogs.AnyAsync(x => x.Slug == updateBlogCommand.Slug && x.Id != updateBlogCommand.Id, cancellationToken))
                return false;


            return true;
        }


        private async Task<bool> ValidCategory(UpdateBlogCommand updateBlogCommand, CancellationToken cancellationToken)
        {
            if (!await _context.BlogCategories.AnyAsync(x => x.Id == updateBlogCommand.CategoryId, cancellationToken))
                return false;


            return true;
        }




       
    }
}