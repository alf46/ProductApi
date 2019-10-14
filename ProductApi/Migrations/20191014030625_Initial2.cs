using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApi.Migrations
{
    public partial class Initial2 : Migration
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
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                values: new object[] { 1, new DateTime(2019, 10, 13, 23, 6, 25, 135, DateTimeKind.Local).AddTicks(7919), "Arroz La Garza", null, 26.95m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "Price" },
                values: new object[] { 2, new DateTime(2019, 10, 13, 23, 6, 25, 136, DateTimeKind.Local).AddTicks(6881), "Huevo, Carton", null, 102.95m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
