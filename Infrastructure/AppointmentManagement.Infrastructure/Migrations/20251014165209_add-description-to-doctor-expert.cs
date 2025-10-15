using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptiontodoctorexpert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DoctorExperts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DoctorExperts");
        }
    }
}
