using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraverSalApiProject.Migrations
{
    /// <inheritdoc />
    public partial class create_add_mig123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "County",
                table: "Visitors",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Visitors",
                newName: "County");
        }
    }
}
