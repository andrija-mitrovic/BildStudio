using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateDatabaseRelationDeviceTypeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyValues_DeviceTypePropertyId",
                table: "DevicePropertyValues",
                column: "DeviceTypePropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePropertyValues_DeviceTypeProperties_DeviceTypePropertyId",
                table: "DevicePropertyValues",
                column: "DeviceTypePropertyId",
                principalTable: "DeviceTypeProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicePropertyValues_DeviceTypeProperties_DeviceTypePropertyId",
                table: "DevicePropertyValues");

            migrationBuilder.DropIndex(
                name: "IX_DevicePropertyValues_DeviceTypePropertyId",
                table: "DevicePropertyValues");
        }
    }
}
