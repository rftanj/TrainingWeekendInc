using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperAdmin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07bc0a1e-5c04-42ca-ac72-fc256cf8208a", "18ab8093-47d7-4c0c-a021-298ee73a4bbe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperAdmin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b0203e9-f672-4e4a-b41c-1cf035c97039", "de5e34ee-3857-43a2-b15a-b3b2b4b36a6a" });
        }
    }
}
