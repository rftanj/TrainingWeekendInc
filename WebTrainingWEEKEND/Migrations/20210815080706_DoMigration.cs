using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTrainingWEEKEND.Migrations
{
    public partial class DoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Menus",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Menus");
        }
    }
}
