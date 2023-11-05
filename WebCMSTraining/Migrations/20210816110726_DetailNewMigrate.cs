using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class DetailNewMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DetailOrders",
                type: "enum('Published','Deleted','Trash')",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "DetailOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Deleted','Trash')");
        }
    }
}
