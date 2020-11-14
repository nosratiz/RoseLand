using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.Search.ModelDto;

namespace OnlineShop.Application.Search.Command
{
    public class SearchCommand : IRequest<List<SearchDto>>
    {
        public string Query { get; set; }
    }


    public class SearchCommandHandler : IRequestHandler<SearchCommand, List<SearchDto>>
    {
        private readonly ICmsDbContext _context;

        public SearchCommandHandler(ICmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<SearchDto>> Handle(SearchCommand request, CancellationToken cancellationToken)
        {
            var blog = await _context.Blogs.Where(x => x.Title.ToLower().Contains(request.Query)
               || x.Description.Contains(request.Query)).ToListAsync(cancellationToken);

            var products = await _context.Products.Where(x => x.Name.ToLower().Contains(request.Query)
            || x.Description.Contains(request.Query)).ToListAsync(cancellationToken);


            var blogsearch = blog.Select(SearchDto.GetSearch).ToList();

            var productSearch = products.Select(SearchDto.GetSearch).ToList();


            return productSearch.Concat(blogsearch).ToList();
        }
    }
}