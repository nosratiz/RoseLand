using System;

namespace OnlineShop.Domain.Entities.UserManagement
{
    public class UserToken
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Ip { get; set; }

        public string UserAgent { get; set; }

        public string Browser { get; set; }

        public string Token { get; set; }

        public bool IsUsed { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime CreateDate { get; set; }
    }
}