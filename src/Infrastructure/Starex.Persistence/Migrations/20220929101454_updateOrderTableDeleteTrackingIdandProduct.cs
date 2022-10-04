using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starex.Persistence.Migrations
{
    public partial class updateOrderTableDeleteTrackingIdandProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TrackingId",
                table: "Packages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingId",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
