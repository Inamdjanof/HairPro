using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairPro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class version_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("37ff6d9f-edde-45c7-864c-39f03c309869"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d9766b9-f8e4-44a0-8e96-856ec0c23f68"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("714354dd-6b61-43f5-8086-24cb9474a481"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleType" },
                values: new object[,]
                {
                    { new Guid("047e5cbd-ffcc-46bf-b32a-215676c2015d"), null, "Barber", null, 2 },
                    { new Guid("0a058d79-380d-4661-a97c-df1a2ef76bb6"), null, "Admin", null, 1 },
                    { new Guid("ca4d75a5-47d0-4c0a-a564-f4c16240e0ea"), null, "Customer", null, 3 }
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "12345678-1234-1234-1234-123456789abc",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dce09a6a-6ca9-44d1-9063-4f470343642c", "16ead505-7f5a-4299-851d-08a49115b55b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("047e5cbd-ffcc-46bf-b32a-215676c2015d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a058d79-380d-4661-a97c-df1a2ef76bb6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca4d75a5-47d0-4c0a-a564-f4c16240e0ea"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleType" },
                values: new object[,]
                {
                    { new Guid("37ff6d9f-edde-45c7-864c-39f03c309869"), null, "Barber", null, 2 },
                    { new Guid("5d9766b9-f8e4-44a0-8e96-856ec0c23f68"), null, "Admin", null, 1 },
                    { new Guid("714354dd-6b61-43f5-8086-24cb9474a481"), null, "Customer", null, 3 }
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "12345678-1234-1234-1234-123456789abc",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b20f255f-ec4d-40f6-8720-359032ad58d7", "ddd9a4f5-5cfe-4b46-9029-5c9b58b9a0a4" });
        }
    }
}
