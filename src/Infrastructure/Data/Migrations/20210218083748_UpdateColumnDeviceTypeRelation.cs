using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateColumnDeviceTypeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypes_DeviceTypes_DeviceTypeId",
                table: "DeviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_DeviceTypes_DeviceTypeId",
                table: "DeviceTypes");

            migrationBuilder.DropColumn(
                name: "DeviceTypeId",
                table: "DeviceTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceTypeId",
                table: "DeviceTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_DeviceTypeId",
                table: "DeviceTypes",
                column: "DeviceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_DeviceTypes_DeviceTypeId",
                table: "DeviceTypes",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
