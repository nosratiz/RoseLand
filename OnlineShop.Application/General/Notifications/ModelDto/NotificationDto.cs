using System;
using OnlineShop.Common.Enum;

namespace OnlineShop.Application.General.Notifications.ModelDto
{
    public class NotificationDto
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public NotificationType NotificationType { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsRead { get; set; }
    }
}