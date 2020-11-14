using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Search.ModelDto
{
    public class SearchDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public SearchType SearchType { get; set; }


        public static SearchDto GetSearch(Blog blog) => new SearchDto
        {
            Title = blog.Title,
            Slug = blog.Slug,
            Image = blog.Image,
            SearchType = SearchType.Blog
        };


        public static SearchDto GetSearch(Product product) => new SearchDto
        {
            Title = product.Name,
            Slug = product.Slug,
            Image = product.Image,
            SearchType = SearchType.Product
        };
    }
}