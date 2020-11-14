using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    AppSettingId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MerchantId = table.Column<string>(nullable: true),
                    DefaultLanguageCode = table.Column<string>(nullable: true),
                    ENamad = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    CopyRight = table.Column<string>(nullable: true),
                    GoogleAnalytic = table.Column<string>(nullable: true),
                    GoogleMaster = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    MaxSlideShow = table.Column<int>(nullable: false),
                    MaintenanceMode = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    SocialMedia = table.Column<string>(nullable: true),
                    Privacy = table.Column<string>(nullable: true),
                    Terms = table.Column<string>(nullable: true),
                    MaxSizeUploadFile = table.Column<int>(nullable: false, defaultValue: 3)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.AppSettingId);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_BlogCategories_BlogCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BlogCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUses",
                columns: table => new
                {
                    ContactUsId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 830, DateTimeKind.Local).AddTicks(4225))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUses", x => x.ContactUsId);
                });

            migrationBuilder.CreateTable(
                name: "DailyStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterUser = table.Column<int>(nullable: false),
                    TotalView = table.Column<int>(nullable: false),
                    TotalOrder = table.Column<int>(nullable: false),
                    TotalRevenue = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    DiscountCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    UsageCount = table.Column<int>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DiscountType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.DiscountCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    FaqId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(nullable: false),
                    Question = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.FaqId);
                });

            migrationBuilder.CreateTable(
                name: "HtmlParts",
                columns: table => new
                {
                    HtmlPartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    UniqueName = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    IsVital = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlParts", x => x.HtmlPartId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    menuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    MenuType = table.Column<int>(nullable: false),
                    UniqueName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 838, DateTimeKind.Local).AddTicks(2179)),
                    Controller = table.Column<string>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    IsVital = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    TotalUniqueView = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalView = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.menuId);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "menuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SlideShows",
                columns: table => new
                {
                    SliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LanguageCode = table.Column<string>(nullable: true, defaultValue: "fa"),
                    Image = table.Column<string>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideShows", x => x.SliderId);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalUser = table.Column<int>(nullable: false),
                    TotalView = table.Column<int>(nullable: false),
                    TotalProduct = table.Column<int>(nullable: false),
                    TotalOrder = table.Column<int>(nullable: false),
                    TotalBlog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    SubscriberId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.SubscriberId);
                });

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    UserFileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    MediaType = table.Column<string>(nullable: true),
                    UniqueId = table.Column<string>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 856, DateTimeKind.Local).AddTicks(3287))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.UserFileId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    DiscountPrice = table.Column<long>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsSpecial = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 2),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ConfirmedNumber = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 854, DateTimeKind.Local).AddTicks(6293)),
                    ExpiredVerification = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 27, 12, 53, 56, 854, DateTimeKind.Local).AddTicks(6555)),
                    ActivationCode = table.Column<Guid>(nullable: false, defaultValue: new Guid("0d7e977f-1043-4774-bf92-810bb3923b2e")),
                    IsEmailConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPhoneConfirmed = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGalleries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGalleries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 826, DateTimeKind.Local).AddTicks(4654)),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    TotalUniqueView = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalView = table.Column<int>(nullable: false, defaultValue: 0),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    UserAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.UserAddressId);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserTokenId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserTokenId);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddressId = table.Column<int>(nullable: false),
                    DiscountCodeId = table.Column<int>(nullable: true),
                    TotalProductPrice = table.Column<long>(nullable: false),
                    FinalAmount = table.Column<long>(nullable: false),
                    DiscountPrice = table.Column<long>(nullable: false),
                    ShipmentPrice = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_DiscountCodes_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_UserAddresses_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "UserAddresses",
                        principalColumn: "UserAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    RefId = table.Column<long>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    orderItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.orderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_OrderId",
                table: "BankTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_ParentId",
                table: "BlogCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserAddressId",
                table: "Orders",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusHistories_OrderId",
                table: "OrderStatusHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGalleries_ProductId",
                table: "ProductGalleries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_ProductId",
                table: "ProductPriceHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ContactUses");

            migrationBuilder.DropTable(
                name: "DailyStatistics");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "HtmlParts");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderStatusHistories");

            migrationBuilder.DropTable(
                name: "ProductGalleries");

            migrationBuilder.DropTable(
                name: "ProductPriceHistories");

            migrationBuilder.DropTable(
                name: "SlideShows");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
