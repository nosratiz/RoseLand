namespace OnlineShop.Application.Common.General
{
    public class PagingOptions
    {
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;

        public string Search { get; set; }
    }
}