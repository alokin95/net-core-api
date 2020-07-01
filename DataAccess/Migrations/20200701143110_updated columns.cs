using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updatedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_City_Address_Country",
                table: "Locations");

            migrationBuilder.CreateTable(
                name: "AppLogs",
                columns: table => new
                {
                    HappenedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Actionid = table.Column<int>(nullable: false),
                    ActionName = table.Column<string>(nullable: true),
                    ActorIdentity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_City_Address_Country_PostalCode",
                table: "Locations",
                columns: new[] { "City", "Address", "Country", "PostalCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLogs");

            migrationBuilder.DropIndex(
                name: "IX_Locations_City_Address_Country_PostalCode",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_City_Address_Country",
                table: "Locations",
                columns: new[] { "City", "Address", "Country" },
                unique: true);
        }
    }
}
