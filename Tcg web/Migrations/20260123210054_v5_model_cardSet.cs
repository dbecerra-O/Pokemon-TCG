using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tcg_web.Migrations
{
    /// <inheritdoc />
    public partial class v5_model_cardSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EnergyTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SetId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EnergyTypes_Name",
                table: "EnergyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SetId",
                table: "Cards",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Sets_SetId",
                table: "Cards",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Sets_SetId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_EnergyTypes_Name",
                table: "EnergyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cards_SetId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "SetId",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EnergyTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    SetId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => new { x.SetId, x.CardId });
                    table.ForeignKey(
                        name: "FK_Contents_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CardId",
                table: "Contents",
                column: "CardId");
        }
    }
}
