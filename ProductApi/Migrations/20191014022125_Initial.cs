using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "Price" },
                values: new object[] { 1, new DateTime(2019, 10, 13, 22, 21, 24, 939, DateTimeKind.Local).AddTicks(2216), "Arroz La Garza", null, 26.95m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "Price" },
                values: new object[] { 2, new DateTime(2019, 10, 13, 22, 21, 24, 940, DateTimeKind.Local).AddTicks(767), "Huevo, Carton", null, 102.95m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
