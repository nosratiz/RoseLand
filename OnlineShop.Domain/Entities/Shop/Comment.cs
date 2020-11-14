using System;
using System.Collections.Generic;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Domain.Entities.Shop
{
    public class Comment
    {

        public Comment()
        {
            Children = new HashSet<Comment>();
        }



        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsDeleted { get; set; }


        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Children { get; }
    }
}