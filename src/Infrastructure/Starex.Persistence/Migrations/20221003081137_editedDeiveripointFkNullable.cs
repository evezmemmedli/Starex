using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starex.Persistence.Migrations
{
    public partial class editedDeiveripointFkNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryPointId",
                table: "PoctAdresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers",
                column: "PoctAdressId",
                principalTable: "PoctAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryPointId",
                table: "PoctAdresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PoctAdresses_PoctAdressId",
                table: "AspNetUsers",
                column: "PoctAdressId",
                principalTable: "PoctAdresses",
                principalColumn: "Id");
        }
    }
}
