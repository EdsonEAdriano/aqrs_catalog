using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aqrsmedia.CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "t_catalog",
                columns: new[] { "id", "category_id", "created_date", "description", "genre_id", "inactivated_date", "media_id", "media_type_id", "media_url", "price", "rating_id", "status" },
                values: new object[] { new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"), new Guid("c313fa89-0025-4d9d-bbd9-d83b29ad72df"), new DateTime(2024, 6, 7, 19, 57, 34, 130, DateTimeKind.Local).AddTicks(9547), "Descrição do catalogo 1", new Guid("db1d5df5-8176-4032-be18-9b3329dc16e9"), null, new Guid("c427b2e1-deeb-45cd-9b84-1d66f90bcb75"), new Guid("ce6875b7-efcb-4da3-bd0e-7813fbd1c479"), "https://localhost:7001/api/Catalog/fdda6ab1-eed4-4856-9e55-b9e96eb2f163", 98.579999999999998, new Guid("fb923c80-e9f7-4098-b8d6-5ebc2dd32315"), "ACTIVE" });

            migrationBuilder.InsertData(
                table: "t_catalog_participant",
                columns: new[] { "id", "catalog_id", "participant_id" },
                values: new object[,]
                {
                    { new Guid("2d5d2a29-c4ed-4ee1-b8a9-d4a9f196f5a0"), new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"), new Guid("c0d8deac-b6b9-489b-b6e3-afab399ed3a5") },
                    { new Guid("a567968f-64d2-419f-a838-6ae462345898"), new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"), new Guid("537f6d12-6d9e-4a82-ae1e-ce734eea6c70") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "t_catalog_participant",
                keyColumn: "id",
                keyValue: new Guid("2d5d2a29-c4ed-4ee1-b8a9-d4a9f196f5a0"));

            migrationBuilder.DeleteData(
                table: "t_catalog_participant",
                keyColumn: "id",
                keyValue: new Guid("a567968f-64d2-419f-a838-6ae462345898"));

            migrationBuilder.DeleteData(
                table: "t_catalog",
                keyColumn: "id",
                keyValue: new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"));
        }
    }
}
