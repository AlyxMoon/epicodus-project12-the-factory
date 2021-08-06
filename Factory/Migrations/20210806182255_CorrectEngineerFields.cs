using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class CorrectEngineerFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CycleTime",
                table: "engineers");

            migrationBuilder.DropColumn(
                name: "ItemsPerCycle",
                table: "engineers");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "engineers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "engineers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "engineers");

            migrationBuilder.AddColumn<int>(
                name: "CycleTime",
                table: "engineers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemsPerCycle",
                table: "engineers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Product",
                table: "engineers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
