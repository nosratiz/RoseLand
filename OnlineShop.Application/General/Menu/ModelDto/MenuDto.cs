using System;
using System.Collections.Generic;
using OnlineShop.Application.General.Menu.Command.CreateMenu;
using OnlineShop.Common.Enum;

namespace OnlineShop.Application.General.Menu.ModelDto
{
    public class MenuDto
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string ParentName { get; set; }

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

        public List<MenuDto> Children { get; set; }

    }
}