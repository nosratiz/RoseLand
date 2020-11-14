﻿using System;
using MediatR;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.SlideShow.Command.CreateSlideShow
{
    public class CreateSlideShowCommand : IRequest<Result<SlideShowDto>>
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string StartDateTime { get; set; }

        public string EndDateTime { get; set; }

        public bool IsVisible { get; set; }

        public int SortOrder { get; set; }
    }
}