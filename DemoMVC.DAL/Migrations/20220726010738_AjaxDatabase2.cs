using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.DAL.Migrations
{
    public partial class AjaxDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistrictId",
                table: "Employee",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_District_DistrictId",
                table: "Employee",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_District_DistrictId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DistrictId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Employee");
        }
    }
}
