using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starex.Persistence.Migrations
{
    public partial class editedDeliveryPointAndAppUserNoActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryPointId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers",
                column: "DeliveryPointId",
                principalTable: "DeliveryPoints",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryPointId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DeliveryPoints_DeliveryPointId",
                table: "AspNetUsers",
                column: "DeliveryPointId",
                principalTable: "DeliveryPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
