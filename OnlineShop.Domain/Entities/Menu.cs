using System;
using System.Collections.Generic;
using OnlineShop.Common.Enum;

namespace OnlineShop.Domain.Entities
{
    public class Menu
    {
        public Menu()
        {
            Children = new HashSet<Menu>();
        }
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public MenuType MenuType { get; set; }

        public string UniqueName { get; set; }

        public DateTime CreationDate { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public int SortOrder { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public bool IsVital { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsPublish { get; set; }

        public int TotalUniqueView { get; set; }

        public int TotalView { get; set; }

        public virtual Menu Parent { get; set; }

        public virtual ICollection<Menu> Children { get; }
    }
}