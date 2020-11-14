using System.Collections.Generic;
using System;
using System.Linq;
using AutoMapper;
using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using OnlineShop.Application.Authentication.Command;
using OnlineShop.Application.Dashboard.ModelDto;
using OnlineShop.Application.General.AppSetting.Command.UpdateSetting;
using OnlineShop.Application.General.AppSetting.ModelDto;
using OnlineShop.Application.General.Blog.Command.CreateBlog;
using OnlineShop.Application.General.Blog.Command.UpdateBlog;
using OnlineShop.Application.General.Blog.ModelDto;
using OnlineShop.Application.General.BlogCategory.Command.CreateCategory;
using OnlineShop.Application.General.BlogCategory.Command.UpdateCategory;
using OnlineShop.Application.General.BlogCategory.ModelDto;
using OnlineShop.Application.General.ContactUs.ModelDto;
using OnlineShop.Application.General.Menu.Command.CreateMenu;
using OnlineShop.Application.General.Menu.Command.UpdateMenu;
using OnlineShop.Application.General.Menu.ModelDto;
using OnlineShop.Application.General.Notifications.ModelDto;
using OnlineShop.Application.General.SlideShow.Command.CreateSlideShow;
using OnlineShop.Application.General.SlideShow.Command.UpdateSlideShow;
using OnlineShop.Application.General.SlideShow.ModelDto;
using OnlineShop.Application.Shop.BankTransactions.ModelDto;
using OnlineShop.Application.Shop.Comments.ModelDto;
using OnlineShop.Application.Shop.DiscountCodes.Command.CreateDiscountCode;
using OnlineShop.Application.Shop.DiscountCodes.Command.UpdateDiscountCode;
using OnlineShop.Application.Shop.DiscountCodes.ModelDto;
using OnlineShop.Application.Shop.Orders.ModelDto;
using OnlineShop.Application.Shop.ProductCategories.Command.CreateCategory;
using OnlineShop.Application.Shop.ProductCategories.Command.UpdateCategory;
using OnlineShop.Application.Shop.ProductCategories.ModelDto;
using OnlineShop.Application.Shop.Products.Command.CreateProduct;
using OnlineShop.Application.Shop.Products.Command.UpdateProduct;
using OnlineShop.Application.Shop.Products.ModelDto;
using OnlineShop.Application.Shop.ProductVariants.Command.CreateCommand;
using OnlineShop.Application.Shop.ProductVariants.Command.UpdateCommand;
using OnlineShop.Application.Shop.ProductVariants.ModelDto;
using OnlineShop.Application.UserAddress.Command.CreateUserAddress;
using OnlineShop.Application.UserAddress.Command.UpdateUserAddress;
using OnlineShop.Application.UserAddress.ModelDto;
using OnlineShop.Application.UserFile.ModelDto;
using OnlineShop.Application.Users.Command.CreateUser;
using OnlineShop.Application.Users.Command.UpdateProfile;
using OnlineShop.Application.Users.Command.UpdateUser;
using OnlineShop.Application.Users.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.Helper;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Entities.statistic;
using OnlineShop.Domain.Entities.UserManagement;

namespace OnlineShop.Application.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region User

            CreateMap<CreateUserCommand, User>().ForMember(x => x.Password, opt => opt.MapFrom(des => PasswordManagement.HashPass(des.Password)))
                .ForMember(x => x.Status, opt => opt.MapFrom(des => Status.Active))
                .ForMember(x => x.RegisterDate, opt => opt.MapFrom(des => DateTime.Now))
                .ForMember(x => x.ActivationCode, opt => opt.MapFrom(des => Guid.NewGuid()))
                .ForMember(x => x.ExpiredVerification, opt => opt.MapFrom(des => DateTime.Now.AddDays(2)));

            CreateMap<UpdateUserCommand, User>();

            CreateMap<User, UserDto>()
                .ForMember(x => x.RoleName, opt => opt.MapFrom(des => des.Role.Name))
                .ForMember(x => x.FullName, opt => opt.MapFrom(des => $"{des.Name} {des.Family}"))
                .ForMember(x => x.UserAddressCount, opt => opt.MapFrom(des => des.UserAddresses.Count))
                .ForMember(x => x.OrderCount, opt => opt.MapFrom(des => des.OrderItems.Count))
                .ForMember(x => x.CommentCount, opt => opt.MapFrom(des => des.Comments.Count));

            CreateMap<UpdateProfileCommand, User>();

            CreateMap<Domain.Entities.Shop.UserAddress, UserAddressDto>();

            CreateMap<CreateUserAddressCommand, Domain.Entities.Shop.UserAddress>();

            CreateMap<UpdateUserAddressCommand, Domain.Entities.Shop.UserAddress>();

            CreateMap<RegisterCommand, User>().ForMember(x => x.Password, opt => opt.MapFrom(des => PasswordManagement.HashPass(des.Password)))
                .ForMember(x => x.Status, opt => opt.MapFrom(des => Status.Deactivate))
                .ForMember(x => x.RoleId, opt => opt.MapFrom(des => Role.User))
                .ForMember(x => x.ActivationCode, opt => opt.MapFrom(des => Guid.NewGuid()))
                .ForMember(x => x.ExpiredVerification, opt => opt.MapFrom(des => DateTime.Now.AddDays(2)))
                .ForMember(x => x.RegisterDate, opt => opt.MapFrom(des => DateTime.Now));
            #endregion

            #region contactUs

            CreateMap<ContactUs, ContactUsDto>();

            #endregion

            #region Blog Category

            CreateMap<BlogCategory, BlogCategoryDto>()
                .ForMember(x => x.ParentName, opt => opt.MapFrom(des => des.Parent.Name));

            CreateMap<UpdateCategoryCommand, BlogCategory>().ForMember(x => x.Slug, opt => opt.MapFrom(des =>
                string.IsNullOrWhiteSpace(des.Slug) ? des.Name.Replace(" ", "-") : FixedUrl.RemoveSpecialChar(des.Slug))); ;

            CreateMap<CreateCategoryCommand, BlogCategory>().ForMember(x => x.BlogCount, opt => opt.MapFrom(des => 0))
                .ForMember(x => x.Slug, opt => opt.MapFrom(des =>
                            string.IsNullOrWhiteSpace(des.Slug) ? des.Name.Replace(" ", "-") : FixedUrl.RemoveSpecialChar(des.Slug)));

            #endregion


            #region blog

            CreateMap<Blog, BlogDto>()
            .ForMember(x => x.Tag, opt => opt.MapFrom(des => JsonConvert.DeserializeObject<List<string>>(des.Tag)));

            CreateMap<CreateBlogCommand, Blog>()
                .ForMember(x => x.PublishDate,
                    opt =>
                        opt.MapFrom(des =>
                            string.IsNullOrWhiteSpace(des.PublishDate) ?
                                (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.PublishDate)))
                .ForMember(x => x.ContentType,
                    opt =>
                        opt.MapFrom(des => ContentType.Article))
                .ForMember(x => x.CreateDate,
                    opt =>
                        opt.MapFrom(des => DateTime.Now))
                .ForMember(x => x.TotalUniqueView,
                    opt =>
                        opt.MapFrom(des => 0))
                .ForMember(x => x.TotalView,
                    opt =>
                        opt.MapFrom(des => 0))
                .ForMember(x => x.Tag,
                    opt =>
                        opt.MapFrom(des => JsonConvert.SerializeObject(des.Tag)))
                .ForMember(x => x.Slug, opt =>
                    opt.MapFrom(des =>
                    string.IsNullOrWhiteSpace(des.Slug) ? des.Title.Replace(" ", "-") :
                        FixedUrl.RemoveSpecialChar(des.Slug).ToEnglishNumbers()));

            CreateMap<UpdateBlogCommand, Blog>()
                .ForMember(x => x.PublishDate, opt =>
                    opt.MapFrom(des => string.IsNullOrWhiteSpace(des.PublishDate) ?
                        (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.PublishDate)))
                .ForMember(x => x.Tag, opt =>
                    opt.MapFrom(des => JsonConvert.SerializeObject(des.Tag)));

            #endregion

            #region Menu

            CreateMap<Menu, MenuDto>().ForMember(x => x.ParentName, opt => opt.MapFrom(des => des.Parent.Title));

            CreateMap<CreateMenuCommand, Menu>().ForMember(x => x.Controller, opt => opt.MapFrom(des => "Page"))
                .ForMember(x => x.Action, opt => opt.MapFrom(des => "index"))
                .ForMember(x => x.CreationDate, opt => opt.MapFrom(des => DateTime.Now))
                .ForMember(x => x.MenuType, opt => opt.MapFrom(des => MenuType.Page));

            CreateMap<UpdateMenuCommand, Menu>();
            #endregion

            #region ProductCategory

            CreateMap<ProductCategory, ProductCategoryDto>().ForMember(x => x.ParentName, opt => opt.MapFrom(des => des.Parent.Name));

            CreateMap<CreateProductCategoryCommand, ProductCategory>().ForMember(x => x.ProductCount, opt => opt.MapFrom(des => 0));

            CreateMap<UpdateProductCategoryCommand, ProductCategory>();

            #endregion

            #region DiscountCode

            CreateMap<DiscountCode, DiscountCodeDto>();

            CreateMap<CreateDiscountCodeCommand, DiscountCode>()
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(des => DateTime.Now))
                .ForMember(x => x.StartDate, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.StartDate) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.StartDate)))
                .ForMember(x => x.EndDateTime, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.EndDateTime) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.EndDateTime)));

            CreateMap<UpdateDiscountCodeCommand, DiscountCode>().ForMember(x => x.StartDate, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.StartDate) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.StartDate)))
                .ForMember(x => x.EndDateTime, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.EndDateTime) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.EndDateTime))); ;

            #endregion

            #region SlideShow

            CreateMap<SlideShow, SlideShowDto>();

            CreateMap<CreateSlideShowCommand, SlideShow>().ForMember(x => x.StartDateTime, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.StartDateTime) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.StartDateTime)))
                .ForMember(x => x.EndDateTime, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.EndDateTime) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.EndDateTime)));
            ;

            CreateMap<UpdateSlideShowCommand, SlideShow>().ForMember(x => x.StartDateTime, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.StartDateTime) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.StartDateTime)))
                .ForMember(x => x.EndDateTime, opt => opt.MapFrom(des => string.IsNullOrWhiteSpace(des.EndDateTime) ? (DateTime?)null : DateTimeConvertor.ToGregorianDateTime(des.EndDateTime)));
            ;

            #endregion

            #region comment

            CreateMap<Comment, CommentDto>();


            #endregion

            #region Order

            CreateMap<Order, OrderDto>().ForMember(x => x.CreateDate, opt => opt.MapFrom(des => DateTimeConvertor.PersianDateTime(des.CreateDate)))
                .ForMember(x => x.DeliveryDate, opt => opt.MapFrom(des => DateTimeConvertor.PersianDate(des.DeliveryDate)));

            CreateMap<OrderItem, OrderItemDto>();

            #endregion

            #region BankTransaction

            CreateMap<BankTransaction, BankTransactionDto>()
                .ForMember(x => x.OrderNumber, opt => opt.MapFrom(des => des.Order.OrderNumber));

            #endregion

            #region Product

            CreateMap<Product, ProductDto>().ForMember(x => x.Price
                , opt =>
                     opt.MapFrom(des => des.ProductVariants.FirstOrDefault().DiscountPrice.HasValue
                                        && des.ProductVariants.FirstOrDefault().DiscountPrice.Value > 0 ?
                     des.ProductVariants.FirstOrDefault(x => x.DiscountPrice.HasValue && x.DiscountPrice > 0).Price :
                 des.ProductVariants.FirstOrDefault().Price)).ForMember(des => des.HasDiscount,
                opt =>
                    opt.MapFrom(des =>
                        des.ProductVariants.Any(x => x.DiscountPrice.HasValue && x.DiscountPrice.Value > 0)))
                .ForMember(x => x.DiscountPrice, opt => opt.MapFrom(des => des.ProductVariants.FirstOrDefault().DiscountPrice.HasValue
                                                                           && des.ProductVariants.FirstOrDefault().DiscountPrice.Value > 0
                    ? des.ProductVariants.FirstOrDefault(x => x.DiscountPrice.HasValue && x.DiscountPrice > 0).DiscountPrice
                    : des.ProductVariants.FirstOrDefault().DiscountPrice))
                .ForMember(x => x.ProductVariantId, opt => opt.MapFrom(des => des.ProductVariants.FirstOrDefault().DiscountPrice.HasValue
                                                                              && des.ProductVariants.FirstOrDefault().DiscountPrice.Value > 0
                         ? des.ProductVariants.FirstOrDefault(x => x.DiscountPrice.HasValue && x.DiscountPrice > 0).Id : des.ProductVariants.FirstOrDefault().Id));

            CreateMap<CreateProductCommand, Product>()
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(des => DateTime.Now))
                .ForMember(x => x.TotalView, opt => opt.MapFrom(des => 0))
                .ForMember(x => x.TotalSailed, opt => opt.MapFrom(des => 0));

            CreateMap<UpdateProductCommand, Product>();

            CreateMap<ProductVariant, ProductVariantDto>();

            CreateMap<CreateProductVariantCommand, ProductVariant>();

            CreateMap<UpdateProductVariantCommand, ProductVariant>();

            #endregion

            #region Stat

            CreateMap<Statistic, StatisticDto>();

            CreateMap<DailyStatistic, DailyStatisticDto>();

            #endregion

            #region AppSetting

            CreateMap<AppSetting, AppSettingDto>();

            CreateMap<UpdateAppSettingCommand, AppSetting>();

            #endregion

            #region File

            CreateMap<Domain.Entities.UserManagement.UserFile, FileUploadDto>();

            #endregion

            CreateMap<Notification, NotificationDto>();

            CreateMap<ProductGallery, ProductGalleryDto>();


        }

    }
}
