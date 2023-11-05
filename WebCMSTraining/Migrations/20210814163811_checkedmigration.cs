using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace WebCMSTraining.Migrations
{
    public partial class checkedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<string>(type: "enum('Published', 'Deleted', 'Trash')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiscountCode = table.Column<int>(type: "int", nullable: false),
                    DiscountName = table.Column<string>(type: "varchar(255)", nullable: true),
                    DiscountType = table.Column<string>(type: "varchar(255)", nullable: true),
                    DiscountValue = table.Column<int>(type: "int", nullable: false),
                    StartPeriod = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndPeriod = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "enum('Deleted', 'Published')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MenuName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "enum('Published','Deleted','Trash')", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
