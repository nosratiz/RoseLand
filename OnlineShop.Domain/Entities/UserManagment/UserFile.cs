using System;

namespace OnlineShop.Domain.Entities.UserManagement
{
    public class UserFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public string Url { get; set; }

        public string Path { get; set; }

        public string Type { get; set; }

        public string MediaType { get; set; }

        public string UniqueId { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime CreateDate { get; }
    }
}