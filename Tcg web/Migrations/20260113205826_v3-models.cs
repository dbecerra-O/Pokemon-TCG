using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tcg_web.Migrations
{
    /// <inheritdoc />
    public partial class v3models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                table: "Collections",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_UserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Collections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                table: "Collections",
                columns: new[] { "UserId", "CardId" });
        }
    }
}
