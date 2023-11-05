using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class SeedDataMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SuperAdmins",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 1, "admin@weekendinc.com", "admin12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
