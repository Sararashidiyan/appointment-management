using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addlocationtodoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityEnglishName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CityEnglishName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Doctors");
        }
    }
}
