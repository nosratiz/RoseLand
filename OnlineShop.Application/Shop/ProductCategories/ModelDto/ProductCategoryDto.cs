namespace OnlineShop.Application.Shop.ProductCategories.ModelDto
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ProductCount { get; set; }
    }
}