using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starex.Persistence.Migrations
{
    public partial class editedDeliveryPointAndPoctadresNoActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PoctAdresses_DeliveryPoints_DeliveryPointId",
                table: "PoctAdresses");

            migrationBuilder.AlterColumn<bool>(
                name: "Payment",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers",
                column: "DeliveryPointId",
                principalTable: "DeliveryPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoctAdresses_DeliveryPoints_DeliveryPointId",
                table: "PoctAdresses",
                column: "DeliveryPointId",
                principalTable: "DeliveryPoints",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PoctAdresses_DeliveryPoints_DeliveryPointId",
                table: "PoctAdresses");

            migrationBuilder.AlterColumn<string>(
                name: "Payment",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers",
                column: "DeliveryPointId",
                principalTable: "DeliveryPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoctAdresses_DeliveryPoints_DeliveryPointId",
                table: "PoctAdresses",
                column: "DeliveryPointId",
                principalTable: "DeliveryPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
