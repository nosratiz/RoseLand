using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class Updateslideshow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "SlideShows");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 854, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(1161),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 27, 12, 53, 56, 854, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("3d7668de-176b-431c-b595-1b9d1962303f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d7e977f-1043-4774-bf92-810bb3923b2e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 520, DateTimeKind.Local).AddTicks(8328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 856, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 500, DateTimeKind.Local).AddTicks(2417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 838, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 491, DateTimeKind.Local).AddTicks(6936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 830, DateTimeKind.Local).AddTicks(4225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 487, DateTimeKind.Local).AddTicks(5988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 826, DateTimeKind.Local).AddTicks(4654));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 854, DateTimeKind.Local).AddTicks(6293),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 12, 53, 56, 854, DateTimeKind.Local).AddTicks(6555),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 30, 20, 49, 12, 519, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d7e977f-1043-4774-bf92-810bb3923b2e"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3d7668de-176b-431c-b595-1b9d1962303f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 856, DateTimeKind.Local).AddTicks(3287),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 520, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "SlideShows",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "fa");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 838, DateTimeKind.Local).AddTicks(2179),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 500, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 830, DateTimeKind.Local).AddTicks(4225),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 491, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 25, 12, 53, 56, 826, DateTimeKind.Local).AddTicks(4654),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 20, 49, 12, 487, DateTimeKind.Local).AddTicks(5988));
        }
    }
}
