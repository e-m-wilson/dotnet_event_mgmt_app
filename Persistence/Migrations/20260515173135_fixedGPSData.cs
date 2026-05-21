using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixedGPSData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Activities",
                type: "numeric(10,7)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Activities",
                type: "numeric(10,7)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Activities",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,7)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Activities",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,7)");
        }
    }
}
