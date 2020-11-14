using System;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;

namespace OnlineShop.Application.Shop.Comments.ModelDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsConfirm { get; set; }


        public virtual UserDto User { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}