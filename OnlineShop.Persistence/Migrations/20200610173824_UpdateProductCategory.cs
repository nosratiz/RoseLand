using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class UpdateProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 31, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("cdd9e6f6-f804-4c46-97b9-4ea4f8b41620"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4a372815-7724-44d5-b3f5-c8d5dc539e61"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 373, DateTimeKind.Local).AddTicks(2737),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 294, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 354, DateTimeKind.Local).AddTicks(5132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 268, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 346, DateTimeKind.Local).AddTicks(8313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 257, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 341, DateTimeKind.Local).AddTicks(5195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 250, DateTimeKind.Local).AddTicks(4484));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3524),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3786),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 12, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4a372815-7724-44d5-b3f5-c8d5dc539e61"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("cdd9e6f6-f804-4c46-97b9-4ea4f8b41620"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 294, DateTimeKind.Local).AddTicks(3410),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 373, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 268, DateTimeKind.Local).AddTicks(1654),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 354, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 257, DateTimeKind.Local).AddTicks(5213),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 346, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 250, DateTimeKind.Local).AddTicks(4484),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 341, DateTimeKind.Local).AddTicks(5195));
        }
    }
}
