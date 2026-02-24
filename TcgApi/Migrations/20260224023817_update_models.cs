using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TcgApi.Migrations
{
    /// <inheritdoc />
    public partial class update_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Rarities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "EnergyTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Rarities");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "EnergyTypes");
        }
    }
}
