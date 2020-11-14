using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class UpdateStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3524),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 31, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("4a372815-7724-44d5-b3f5-c8d5dc539e61"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("06bda10d-25ff-472e-b9df-e0c8e543e34b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 294, DateTimeKind.Local).AddTicks(3410),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 181, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.AddColumn<long>(
                name: "TotalRevenue",
                table: "Statistics",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 268, DateTimeKind.Local).AddTicks(1654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 162, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 257, DateTimeKind.Local).AddTicks(5213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 154, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 250, DateTimeKind.Local).AddTicks(4484),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 148, DateTimeKind.Local).AddTicks(6946));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "Statistics");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6518),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 8, 14, 11, 179, DateTimeKind.Local).AddTicks(6784),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 31, 19, 18, 13, 292, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("06bda10d-25ff-472e-b9df-e0c8e543e34b"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4a372815-7724-44d5-b3f5-c8d5dc539e61"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 181, DateTimeKind.Local).AddTicks(2716),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 294, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 162, DateTimeKind.Local).AddTicks(1490),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 268, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 154, DateTimeKind.Local).AddTicks(6192),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 257, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 29, 8, 14, 11, 148, DateTimeKind.Local).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 29, 19, 18, 13, 250, DateTimeKind.Local).AddTicks(4484));
        }
    }
}
