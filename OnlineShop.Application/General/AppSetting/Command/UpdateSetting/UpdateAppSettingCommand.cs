﻿using MediatR;
using OnlineShop.Common.Result;

namespace OnlineShop.Application.General.AppSetting.Command.UpdateSetting
{
    public class UpdateAppSettingCommand : IRequest<Result>
    {
        public string Image { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MerchantId { get; set; }

        public string DefaultLanguageCode { get; set; }

        public string ENamad { get; set; }

        public string Logo { get; set; }

        public string CopyRight { get; set; }

        public string GoogleAnalytic { get; set; }

        public string GoogleMaster { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int MaxSlideShow { get; set; }

        public bool MaintenanceMode { get; set; }

        public string Email { get; set; }

        public string SocialMedia { get; set; }

        public string Privacy { get; set; }

        public string Terms { get; set; }
        public int MaxSizeUploadFile { get; set; }

    }
}