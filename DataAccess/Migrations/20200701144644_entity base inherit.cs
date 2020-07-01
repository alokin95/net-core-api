using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class entitybaseinherit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HappenedAt",
                table: "AppLogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AppLogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AppLogs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AppLogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppLogs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AppLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AppLogs");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AppLogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "HappenedAt",
                table: "AppLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
