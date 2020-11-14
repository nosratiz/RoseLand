using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class UpdateorderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 30, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("06bda10d-25ff-472e-b9df-e0c8e543e34b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3a34473c-8373-44f1-8515-c35708f60e85"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 181, DateTimeKind.Local).AddTicks(2716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 253, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.AddColumn<int>(
                name: "ProductVariantId",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 162, DateTimeKind.Local).AddTicks(1490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 233, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 154, DateTimeKind.Local).AddTicks(6192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 225, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 148, DateTimeKind.Local).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 219, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductVariants_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "productVariantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductVariants_ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductVariantId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3479),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 21, 37, 5, 251, DateTimeKind.Local).AddTicks(3746),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 31, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3a34473c-8373-44f1-8515-c35708f60e85"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("06bda10d-25ff-472e-b9df-e0c8e543e34b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 253, DateTimeKind.Local).AddTicks(929),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 181, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 233, DateTimeKind.Local).AddTicks(3924),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 162, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 225, DateTimeKind.Local).AddTicks(3140),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 154, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 21, 37, 5, 219, DateTimeKind.Local).AddTicks(3194),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 148, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
