using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 21, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(2119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 20, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("0f1ece16-ba9b-4beb-92ea-ec97fcc5745a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d01790ee-f199-48b9-9f61-823c5cac5889"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 932, DateTimeKind.Local).AddTicks(7490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 650, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.AddColumn<int>(
                name: "NotificationType",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 912, DateTimeKind.Local).AddTicks(8795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 629, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 905, DateTimeKind.Local).AddTicks(4468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 621, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 899, DateTimeKind.Local).AddTicks(9290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 615, DateTimeKind.Local).AddTicks(7908));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "Notifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(5860),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 20, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 21, 22, 2, 18, 931, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d01790ee-f199-48b9-9f61-823c5cac5889"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("0f1ece16-ba9b-4beb-92ea-ec97fcc5745a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 650, DateTimeKind.Local).AddTicks(3102),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 932, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 629, DateTimeKind.Local).AddTicks(5997),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 912, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 621, DateTimeKind.Local).AddTicks(7325),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 905, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 615, DateTimeKind.Local).AddTicks(7908),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 19, 22, 2, 18, 899, DateTimeKind.Local).AddTicks(9290));
        }
    }
}
