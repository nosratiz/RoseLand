using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class AddProductVariant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistories_Products_ProductId",
                table: "ProductPriceHistories");

            migrationBuilder.DropIndex(
                name: "IX_ProductPriceHistories_ProductId",
                table: "ProductPriceHistories");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductPriceHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 30, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("3a34473c-8373-44f1-8515-c35708f60e85"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3d7668de-176b-431c-b595-1b9d1962303f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 253, DateTimeKind.Local).AddTicks(929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 520, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "ProductPriceHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 233, DateTimeKind.Local).AddTicks(3924),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 500, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 225, DateTimeKind.Local).AddTicks(3140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 491, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 219, DateTimeKind.Local).AddTicks(3194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 487, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    productVariantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    DiscountPrice = table.Column<long>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    BoxType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.productVariantId);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_ProductVariantId",
                table: "ProductPriceHistories",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistories_ProductVariants_ProductVariantId",
                table: "ProductPriceHistories",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "productVariantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistories_ProductVariants_ProductVariantId",
                table: "ProductPriceHistories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductPriceHistories_ProductVariantId",
                table: "ProductPriceHistories");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "ProductPriceHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(898),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(1161),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 30, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3d7668de-176b-431c-b595-1b9d1962303f"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3a34473c-8373-44f1-8515-c35708f60e85"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 520, DateTimeKind.Local).AddTicks(8328),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 253, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.AddColumn<long>(
                name: "DiscountPrice",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductPriceHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 500, DateTimeKind.Local).AddTicks(2417),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 233, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 491, DateTimeKind.Local).AddTicks(6936),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 225, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 487, DateTimeKind.Local).AddTicks(5988),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 219, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_ProductId",
                table: "ProductPriceHistories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistories_Products_ProductId",
                table: "ProductPriceHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
