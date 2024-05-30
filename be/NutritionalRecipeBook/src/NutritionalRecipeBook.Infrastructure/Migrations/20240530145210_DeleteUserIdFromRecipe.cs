using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserIdFromRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes");

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17b82c33-f9c4-4d95-a336-04f68fd61ce2"), "Bell Pepper" },
                    { new Guid("1836aae7-675d-42dc-b28a-172dd2e3c137"), "Onion" },
                    { new Guid("73c48669-bb3e-4f6c-934a-02ac1d43d060"), "Cucumber" },
                    { new Guid("93f49b2f-6996-4322-b1ca-9ca74ba99947"), "Carrot" },
                    { new Guid("bfb2b567-170a-4afc-bc3b-544e46ef18fa"), "Tomato" },
                    { new Guid("e2799f88-709c-40b9-a21c-bbc31689e440"), "Garlic" },
                    { new Guid("fd7962f4-fe4e-4b91-a4e0-8ed1b282f7c5"), "Lettuce" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("17b82c33-f9c4-4d95-a336-04f68fd61ce2"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("1836aae7-675d-42dc-b28a-172dd2e3c137"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("73c48669-bb3e-4f6c-934a-02ac1d43d060"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("93f49b2f-6996-4322-b1ca-9ca74ba99947"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("bfb2b567-170a-4afc-bc3b-544e46ef18fa"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e2799f88-709c-40b9-a21c-bbc31689e440"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("fd7962f4-fe4e-4b91-a4e0-8ed1b282f7c5"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
