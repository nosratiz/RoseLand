using System;
using OnlineShop.Common.Enum;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Domain.Entities
{
    public class Blog
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public string Slug { get; set; }

        public string Tag { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? PublishDate { get; set; }

        public int TotalUniqueView { get; set; }

        public int TotalView { get; set; }

        public string Image { get; set; }



        public virtual User User { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }


    }
}