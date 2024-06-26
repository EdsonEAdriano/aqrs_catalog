using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqrsmedia.CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    mediaid = table.Column<Guid>(name: "media_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mediaurl = table.Column<string>(name: "media_url", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false),
                    mediatypeid = table.Column<Guid>(name: "media_type_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    categoryid = table.Column<Guid>(name: "category_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    genreid = table.Column<Guid>(name: "genre_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ratingid = table.Column<Guid>(name: "rating_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createddate = table.Column<DateTime>(name: "created_date", type: "datetime(6)", nullable: false),
                    inactivateddate = table.Column<DateTime>(name: "inactivated_date", type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_catalog", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "t_catalog_participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CatalogId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParticipantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_catalog_participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_catalog_participant_t_catalog_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "t_catalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_t_catalog_participant_CatalogId",
                table: "t_catalog_participant",
                column: "CatalogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_catalog_participant");

            migrationBuilder.DropTable(
                name: "t_catalog");
        }
    }
}
