using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqrsmedia.CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNameFromCatalogParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_catalog_participant_t_catalog_CatalogId",
                table: "t_catalog_participant");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "t_catalog_participant",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "t_catalog_participant",
                newName: "participant_id");

            migrationBuilder.RenameColumn(
                name: "CatalogId",
                table: "t_catalog_participant",
                newName: "catalog_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_catalog_participant_CatalogId",
                table: "t_catalog_participant",
                newName: "IX_t_catalog_participant_catalog_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "t_catalog_participant",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_t_catalog_participant_t_catalog_catalog_id",
                table: "t_catalog_participant",
                column: "catalog_id",
                principalTable: "t_catalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_catalog_participant_t_catalog_catalog_id",
                table: "t_catalog_participant");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "t_catalog_participant",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "participant_id",
                table: "t_catalog_participant",
                newName: "ParticipantId");

            migrationBuilder.RenameColumn(
                name: "catalog_id",
                table: "t_catalog_participant",
                newName: "CatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_t_catalog_participant_catalog_id",
                table: "t_catalog_participant",
                newName: "IX_t_catalog_participant_CatalogId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "t_catalog_participant",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_t_catalog_participant_t_catalog_CatalogId",
                table: "t_catalog_participant",
                column: "CatalogId",
                principalTable: "t_catalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
