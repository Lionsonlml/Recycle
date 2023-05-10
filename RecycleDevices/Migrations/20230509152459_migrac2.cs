using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecycleDevices.Migrations
{
    /// <inheritdoc />
    public partial class migrac2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Apointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Apointment");
        }
    }
}
