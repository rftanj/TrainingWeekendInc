using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class GetMigrationNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "enum('Published','Deleted','Trash')",
                nullable: false,
                defaultValue: "Published");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");
        }
    }
}
