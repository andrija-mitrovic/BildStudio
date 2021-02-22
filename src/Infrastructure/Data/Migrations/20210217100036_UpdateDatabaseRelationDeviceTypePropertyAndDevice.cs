using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateDatabaseRelationDeviceTypePropertyAndDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyValues_DeviceId",
                table: "DevicePropertyValues",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePropertyValues_Devices_DeviceId",
                table: "DevicePropertyValues",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicePropertyValues_Devices_DeviceId",
                table: "DevicePropertyValues");

            migrationBuilder.DropIndex(
                name: "IX_DevicePropertyValues_DeviceId",
                table: "DevicePropertyValues");
        }
    }
}
