using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateDatabaseRelationDeviceTypeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypeProperties_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypeProperties_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeProperties",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypeProperties_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypeProperties_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeProperties",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
