using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecycleDevices.Migrations
{
    /// <inheritdoc />
    public partial class migra1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Apointment",
                newName: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Apointment",
                newName: "Description");
        }
    }
}
