using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class AddNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(5860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 20, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 14, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("d01790ee-f199-48b9-9f61-823c5cac5889"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e0351049-1caf-427c-97c2-15ce0b188138"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 650, DateTimeKind.Local).AddTicks(3102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 999, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 629, DateTimeKind.Local).AddTicks(5997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 980, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 621, DateTimeKind.Local).AddTicks(7325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 972, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 615, DateTimeKind.Local).AddTicks(7908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 966, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(8751),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 14, 11, 6, 43, 997, DateTimeKind.Local).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 20, 9, 39, 50, 648, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e0351049-1caf-427c-97c2-15ce0b188138"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("d01790ee-f199-48b9-9f61-823c5cac5889"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 999, DateTimeKind.Local).AddTicks(4951),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 650, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 980, DateTimeKind.Local).AddTicks(6863),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 629, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 972, DateTimeKind.Local).AddTicks(7356),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 621, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 12, 11, 6, 43, 966, DateTimeKind.Local).AddTicks(7187),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 18, 9, 39, 50, 615, DateTimeKind.Local).AddTicks(7908));
        }
    }
}
