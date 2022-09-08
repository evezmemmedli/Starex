using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starex.Persistence.Migrations
{
    public partial class updateBrandandCountryConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Flag",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Flag",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Flag",
                table: "Countries",
                column: "Flag",
                unique: true,
                filter: "[Flag] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Flag",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Flag",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Flag",
                table: "Countries",
                column: "Flag",
                unique: true);
        }
    }
}
