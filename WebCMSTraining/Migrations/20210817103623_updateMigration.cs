using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "enum('Published','Unpublished','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Deleted','Published')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Menus",
                type: "enum('Published','Unpublished','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Deleted','Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Discounts",
                type: "enum('Unpublished', 'Published', 'Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Deleted', 'Published')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DetailOrders",
                type: "enum('Published','Unpublished','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Deleted','Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Categories",
                type: "enum('Published', 'Unpublished', 'Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published', 'Deleted', 'Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "enum('Published','Unpublished','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Deleted','Trash')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "enum('Deleted','Published')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Unpublished','Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Menus",
                type: "enum('Published','Deleted','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Unpublished','Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Discounts",
                type: "enum('Deleted', 'Published')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Unpublished', 'Published', 'Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "DetailOrders",
                type: "enum('Published','Deleted','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Unpublished','Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Categories",
                type: "enum('Published', 'Deleted', 'Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published', 'Unpublished', 'Trash')");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "enum('Published','Deleted','Trash')",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "enum('Published','Unpublished','Trash')");
        }
    }
}
