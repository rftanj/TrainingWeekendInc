using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperAdmins",
                table: "SuperAdmins");

            migrationBuilder.RenameTable(
                name: "SuperAdmins",
                newName: "SuperAdmin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperAdmin",
                table: "SuperAdmin",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SuperAdmin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "24fac0d7-ba49-4f1f-b95d-dadac350c04b", "72e8f678-49fb-4b6b-aae2-0078aa1ce787" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperAdmin",
                table: "SuperAdmin");

            migrationBuilder.RenameTable(
                name: "SuperAdmin",
                newName: "SuperAdmins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperAdmins",
                table: "SuperAdmins",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bbd23a7-5eac-4cf1-b40e-6dc9201e6172", "565d5e02-ab5b-480e-a987-6122ba5e7d6b" });
        }
    }
}
