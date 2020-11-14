namespace OnlineShop.Domain.Entities.statistic
{
    public class Statistic
    {
        public int Id { get; set; }

        public int TotalUser { get; set; }

        public int TotalView { get; set; }

        public int TotalProduct { get; set; }

        public int TotalOrder { get; set; }

        public int TotalBlog { get; set; }

        public long TotalRevenue { get; set; }
    }
}