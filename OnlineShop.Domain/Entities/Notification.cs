using System;
using OnlineShop.Common.Enum;

namespace OnlineShop.Domain.Entities
{
    public class Notification
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public NotificationType NotificationType { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
    }
}