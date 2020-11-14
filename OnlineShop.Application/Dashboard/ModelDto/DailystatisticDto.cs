using System;

namespace OnlineShop.Application.Dashboard.ModelDto
{
    public class DailyStatisticDto
    {
        public Guid Id { get; set; }

        public int RegisterUser { get; set; }

        public int TotalView { get; set; }

        public int TotalOrder { get; set; }

        public long TotalRevenue { get; set; }

        public DateTime Date { get; set; }
    }
}