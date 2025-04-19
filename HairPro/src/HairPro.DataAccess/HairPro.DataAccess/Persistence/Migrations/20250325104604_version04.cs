using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairPro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class version04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarberQueues");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ResponsibleBarberId",
                table: "BarberShop",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "BarberPortfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BarberId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberPortfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberPortfolios_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleType" },
                values: new object[,]
                {
                    { new Guid("1166f002-a2ee-421f-9074-42e55a04d8e1"), null, "Barber", null, 2 },
                    { new Guid("925e6b15-5497-40cf-8061-93985f31949d"), null, "Customer", null, 3 },
                    { new Guid("e557ab8c-7d12-4e13-9b1b-fede774f39fa"), null, "Admin", null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "12345678-1234-1234-1234-123456789abc",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "943f2271-16ee-4d73-8574-91be59b6c0bd", "4deaa525-dfb2-497f-81fc-7d71bd3ac425" });

            migrationBuilder.CreateIndex(
                name: "IX_BarberPortfolios_BarberId",
                table: "BarberPortfolios",
                column: "BarberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarberPortfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1166f002-a2ee-421f-9074-42e55a04d8e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("925e6b15-5497-40cf-8061-93985f31949d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e557ab8c-7d12-4e13-9b1b-fede774f39fa"));

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleBarberId",
                table: "BarberShop",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "BarberQueues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BarberId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    QueueNumber = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarberQueues_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarberQueues_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BarberQueues_BarberId_OrderId",
                table: "BarberQueues",
                columns: new[] { "BarberId", "OrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BarberQueues_OrderId",
                table: "BarberQueues",
                column: "OrderId");
        }
    }
}
