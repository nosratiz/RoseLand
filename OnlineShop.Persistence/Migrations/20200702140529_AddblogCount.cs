using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class AddblogCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 4, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 21, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("e0b12f36-7a85-48b5-9781-5ab43972748d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0f1ece16-ba9b-4beb-92ea-ec97fcc5745a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 292, DateTimeKind.Local).AddTicks(8493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 932, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 273, DateTimeKind.Local).AddTicks(1705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 912, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 265, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 905, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 260, DateTimeKind.Local).AddTicks(2832),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 899, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.AddColumn<int>(
                name: "BlogCount",
                table: "BlogCategories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogCount",
                table: "BlogCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(2119),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 4, 18, 35, 29, 291, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0f1ece16-ba9b-4beb-92ea-ec97fcc5745a"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("e0b12f36-7a85-48b5-9781-5ab43972748d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 932, DateTimeKind.Local).AddTicks(7490),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 292, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 912, DateTimeKind.Local).AddTicks(8795),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 273, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 905, DateTimeKind.Local).AddTicks(4468),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 265, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 899, DateTimeKind.Local).AddTicks(9290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 18, 35, 29, 260, DateTimeKind.Local).AddTicks(2832));
        }
    }
}
