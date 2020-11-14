using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Common.Interface.Statistic;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.Blog.Command.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<BlogDto>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        private readonly IStatisticService _statisticService;

        public CreateBlogCommandHandler(ICmsDbContext context, IMapper mapper, ICurrentUserService currentUser, IStatisticService statisticService)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
            _statisticService = statisticService;
        }

        public async Task<Result<BlogDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Domain.Entities.Blog>(request);

            blog.UserId = int.Parse(_currentUser.UserId);

            await _context.Blogs.AddAsync(blog, cancellationToken);

            await _statisticService.UpdateBlogCount(true, cancellationToken);

            var category = await _context.BlogCategories.SingleOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);

            category.BlogCount += 1;

            await _context.SaveAsync(cancellationToken);

            return Result<BlogDto>.SuccessFull(_mapper.Map<BlogDto>(blog));
        }
    }
}