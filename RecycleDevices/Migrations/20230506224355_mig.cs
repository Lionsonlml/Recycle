using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecycleDevices.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "Apointment",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Apointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Apointment");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Apointment",
                newName: "EnrollmentDate");
        }
    }
}
