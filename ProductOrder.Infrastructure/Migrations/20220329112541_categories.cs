using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductOrder.API.Migrations
{
    public partial class categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DeleteData(
            //     table: "Products",
            //     keyColumn: "Id",
            //     keyValue: new Guid("39c857ff-bba1-4fd4-99a7-0e3af426d680"));

            // migrationBuilder.DeleteData(
            //     table: "Products",
            //     keyColumn: "Id",
            //     keyValue: new Guid("dc18e5ee-ef75-4cd7-89cd-ed4321eb4eb9"));
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                }
            );

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { new Guid("39c857ff-bba1-4fd4-99a7-0e3af426d680"), "test2Desc", "test2", 25m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { new Guid("dc18e5ee-ef75-4cd7-89cd-ed4321eb4eb9"), "test1Desc", "test1", 22m });
        }
    }
}
