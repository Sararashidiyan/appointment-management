using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeappointmentauditefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Appointments",
                newName: "ChangeStateAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangeStateAt",
                table: "Appointments",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<long>(
                name: "CreatedUserId",
                table: "Appointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedUserId",
                table: "Appointments",
                type: "bigint",
                nullable: true);
        }
    }
}
