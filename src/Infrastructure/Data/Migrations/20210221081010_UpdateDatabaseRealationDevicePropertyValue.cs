using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateDatabaseRealationDevicePropertyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicePropertyValues_Devices_DeviceId",
                table: "DevicePropertyValues");

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePropertyValues_Devices_DeviceId",
                table: "DevicePropertyValues",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicePropertyValues_Devices_DeviceId",
                table: "DevicePropertyValues");

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePropertyValues_Devices_DeviceId",
                table: "DevicePropertyValues",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
