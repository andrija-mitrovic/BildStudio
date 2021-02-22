using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateColumnDeviceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceTypeId",
                table: "DeviceTypes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
