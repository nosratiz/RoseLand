using OnlineShop.Application.Common.General;

namespace OnlineShop.Application.Shop.Products.ModelDto
{
    public class AdvanceFilterProduct : PagingOptions
    {
        public int? CategoryId { get; set; }

        public long MinPrice { get; set; } = 0;

        public long MaxPrice { get; set; } = 100000000;

        public string SortOrder { get; set; } = "default";

        public bool Desc { get; set; }
    }
}