using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starex.Persistence.Migrations
{
    public partial class packageweightsttringchangedtodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers");


            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers",
                column: "PoctAdressId",
                principalTable: "PoctAdresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPrice",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers",
                column: "PoctAdressId",
                principalTable: "PoctAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
