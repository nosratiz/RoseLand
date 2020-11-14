using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class removeTotalCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCount",
                table: "DiscountCodes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(8751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 14, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 12, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("e0351049-1caf-427c-97c2-15ce0b188138"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cdd9e6f6-f804-4c46-97b9-4ea4f8b41620"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 999, DateTimeKind.Local).AddTicks(4951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 373, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 980, DateTimeKind.Local).AddTicks(6863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 354, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 972, DateTimeKind.Local).AddTicks(7356),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 346, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 966, DateTimeKind.Local).AddTicks(7187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 341, DateTimeKind.Local).AddTicks(5195));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 22, 8, 24, 371, DateTimeKind.Local).AddTicks(6535),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 14, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cdd9e6f6-f804-4c46-97b9-4ea4f8b41620"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("e0351049-1caf-427c-97c2-15ce0b188138"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 373, DateTimeKind.Local).AddTicks(2737),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 999, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 354, DateTimeKind.Local).AddTicks(5132),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 980, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.AddColumn<int>(
                name: "TotalCount",
                table: "DiscountCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 346, DateTimeKind.Local).AddTicks(8313),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 972, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 10, 22, 8, 24, 341, DateTimeKind.Local).AddTicks(5195),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 966, DateTimeKind.Local).AddTicks(7187));
        }
    }
}
