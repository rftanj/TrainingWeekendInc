using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class MigrationTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperAdmin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b0203e9-f672-4e4a-b41c-1cf035c97039", "de5e34ee-3857-43a2-b15a-b3b2b4b36a6a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperAdmin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "24fac0d7-ba49-4f1f-b95d-dadac350c04b", "72e8f678-49fb-4b6b-aae2-0078aa1ce787" });
        }
    }
}
