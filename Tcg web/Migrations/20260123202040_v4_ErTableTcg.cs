using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tcg_web.Migrations
{
    /// <inheritdoc />
    public partial class v3_ErTableTcg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Rarities_RarityId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Sets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RarityId",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnergyTypeId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EnergyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_EnergyTypeId",
                table: "Cards",
                column: "EnergyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_EnergyTypes_EnergyTypeId",
                table: "Cards",
                column: "EnergyTypeId",
                principalTable: "EnergyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Rarities_RarityId",
                table: "Cards",
                column: "RarityId",
                principalTable: "Rarities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_EnergyTypes_EnergyTypeId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Rarities_RarityId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "EnergyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cards_EnergyTypeId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "EnergyTypeId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RarityId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Rarities_RarityId",
                table: "Cards",
                column: "RarityId",
                principalTable: "Rarities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
