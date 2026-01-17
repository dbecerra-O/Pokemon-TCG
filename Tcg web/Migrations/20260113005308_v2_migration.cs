using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tcg_web.Migrations
{
    /// <inheritdoc />
    public partial class v2_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Rarity_RarityId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Type_TypeId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_Cards_CardId",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_Package_PackageId",
                table: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rarity",
                table: "Rarity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "Types");

            migrationBuilder.RenameTable(
                name: "Rarity",
                newName: "Rarities");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "Packages");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.RenameIndex(
                name: "IX_Type_Name",
                table: "Types",
                newName: "IX_Types_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Rarity_Name",
                table: "Rarities",
                newName: "IX_Rarities_Name");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Contents",
                newName: "SetId");

            migrationBuilder.RenameIndex(
                name: "IX_Content_CardId",
                table: "Contents",
                newName: "IX_Contents_CardId");

            migrationBuilder.AddColumn<int>(
                name: "SetId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rarities",
                table: "Rarities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                columns: new[] { "SetId", "CardId" });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SetId",
                table: "Packages",
                column: "SetId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Cards_CardId",
                table: "Contents",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Sets_SetId",
                table: "Contents",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Sets_SetId",
                table: "Packages",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Rarities_RarityId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Types_TypeId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Cards_CardId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Sets_SetId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Sets_SetId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rarities",
                table: "Rarities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SetId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "SetId",
                table: "Packages");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "Type");

            migrationBuilder.RenameTable(
                name: "Rarities",
                newName: "Rarity");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "Package");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Types_Name",
                table: "Type",
                newName: "IX_Type_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Rarities_Name",
                table: "Rarity",
                newName: "IX_Rarity_Name");

            migrationBuilder.RenameColumn(
                name: "SetId",
                table: "Content",
                newName: "PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_CardId",
                table: "Content",
                newName: "IX_Content_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rarity",
                table: "Rarity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                columns: new[] { "PackageId", "CardId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Rarity_RarityId",
                table: "Cards",
                column: "RarityId",
                principalTable: "Rarity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Type_TypeId",
                table: "Cards",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Cards_CardId",
                table: "Content",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Package_PackageId",
                table: "Content",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
