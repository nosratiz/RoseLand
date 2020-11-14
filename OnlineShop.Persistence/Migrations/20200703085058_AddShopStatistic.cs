using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class AddShopStatistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(8816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 5, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(9100),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 4, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("e35acb17-7567-4593-a7a7-ca1904992866"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e0b12f36-7a85-48b5-9781-5ab43972748d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 997, DateTimeKind.Local).AddTicks(5002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 292, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.AddColumn<int>(
                name: "TotalSailed",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalView",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 976, DateTimeKind.Local).AddTicks(3515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 273, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 968, DateTimeKind.Local).AddTicks(5504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 265, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 963, DateTimeKind.Local).AddTicks(1037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 260, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.CreateTable(
                name: "ShopStatistics",
                columns: table => new
                {
                    ShopStatisticId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    ProductVariantId = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStatistics", x => x.ShopStatisticId);
                    table.ForeignKey(
                        name: "FK_ShopStatistics_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "productVariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopStatistics_ProductVariantId",
                table: "ShopStatistics",
                column: "ProductVariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopStatistics");

            migrationBuilder.DropColumn(
                name: "TotalSailed",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalView",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2285),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 4, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2550),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 5, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e0b12f36-7a85-48b5-9781-5ab43972748d"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("e35acb17-7567-4593-a7a7-ca1904992866"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 292, DateTimeKind.Local).AddTicks(8493),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 997, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 273, DateTimeKind.Local).AddTicks(1705),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 976, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 265, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 968, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 260, DateTimeKind.Local).AddTicks(2832),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 963, DateTimeKind.Local).AddTicks(1037));
        }
    }
}
