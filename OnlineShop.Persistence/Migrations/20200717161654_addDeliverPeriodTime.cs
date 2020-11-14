using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public partial class addDeliverPeriodTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalProductPrice",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 430, DateTimeKind.Local).AddTicks(4344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 20, 46, 54, 430, DateTimeKind.Local).AddTicks(4605),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 5, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("8c1a8b7f-cb50-4919-b0ed-c1ca78e90c19"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e35acb17-7567-4593-a7a7-ca1904992866"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 433, DateTimeKind.Local).AddTicks(5568),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 997, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.AddColumn<int>(
                name: "DeliverPeriodTime",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 411, DateTimeKind.Local).AddTicks(3148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 976, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 404, DateTimeKind.Local).AddTicks(927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 968, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 399, DateTimeKind.Local).AddTicks(356),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 963, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.CreateTable(
                name: "UserDiscountCodes",
                columns: table => new
                {
                    UserDiscountCodeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    DiscountCodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscountCodes", x => x.UserDiscountCodeId);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_DiscountCodes_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_DiscountCodeId",
                table: "UserDiscountCodes",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_UserId",
                table: "UserDiscountCodes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiscountCodes");

            migrationBuilder.DropColumn(
                name: "DeliverPeriodTime",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(8816),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 430, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredVerification",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 5, 13, 20, 57, 995, DateTimeKind.Local).AddTicks(9100),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 19, 20, 46, 54, 430, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivationCode",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e35acb17-7567-4593-a7a7-ca1904992866"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8c1a8b7f-cb50-4919-b0ed-c1ca78e90c19"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 997, DateTimeKind.Local).AddTicks(5002),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 433, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.AddColumn<long>(
                name: "TotalProductPrice",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 976, DateTimeKind.Local).AddTicks(3515),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 411, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ContactUses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 968, DateTimeKind.Local).AddTicks(5504),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 404, DateTimeKind.Local).AddTicks(927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 3, 13, 20, 57, 963, DateTimeKind.Local).AddTicks(1037),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 17, 20, 46, 54, 399, DateTimeKind.Local).AddTicks(356));
        }
    }
}
