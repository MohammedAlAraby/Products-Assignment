using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsWebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ImgURL = table.Column<string>(nullable: true),
                    CateogryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Electronics" },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CateogryID", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "", "Battery", 90m, 120 },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "", "Screen", 150m, 80 },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "", "Headphones", 60m, 200 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
