using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCMSTraining.Migrations
{
    public partial class SeedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "SuperAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "SuperAdmins",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "SuperAdmins",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "SuperAdmins",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "SuperAdmins",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "SuperAdmins",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SuperAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "610d828f-e461-458d-885f-21b6e2488919", "c173ed79-c06c-40a9-8959-80d719dc213a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SuperAdmins");
        }
    }
}
