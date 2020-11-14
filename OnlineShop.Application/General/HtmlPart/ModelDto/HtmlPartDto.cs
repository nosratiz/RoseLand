﻿namespace OnlineShop.Application.General.HtmlPart.ModelDto
{
    public class HtmlPartDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string UniqueName { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public bool IsVital { get; set; }
    }
}