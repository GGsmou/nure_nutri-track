using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07635319-6b55-4cb2-ba37-611f771aeb57"), "Tomato" },
                    { new Guid("28dee073-6556-46bb-9055-71f9d536e947"), "Cucumber" },
                    { new Guid("7c753fe6-5409-444c-95c6-e5adaf71ebc6"), "Onion" },
                    { new Guid("a515d859-e2fa-4bd7-803c-f169281b50b4"), "Garlic" },
                    { new Guid("b3dc04e0-a4c9-4929-957d-c509e9a1b4c5"), "Lettuce" },
                    { new Guid("bfa0ca70-344c-4641-8685-dc834e5a5f8b"), "Carrot" },
                    { new Guid("e018ddca-c0dc-4a6c-99aa-ee54714f0560"), "Bell Pepper" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("07635319-6b55-4cb2-ba37-611f771aeb57"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("28dee073-6556-46bb-9055-71f9d536e947"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7c753fe6-5409-444c-95c6-e5adaf71ebc6"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a515d859-e2fa-4bd7-803c-f169281b50b4"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b3dc04e0-a4c9-4929-957d-c509e9a1b4c5"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("bfa0ca70-344c-4641-8685-dc834e5a5f8b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e018ddca-c0dc-4a6c-99aa-ee54714f0560"));
        }
    }
}
