using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntVoteEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Votes",
                table: "Recipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("27c9d58c-c8ef-435d-b1a4-1f59f5616504"), "Bell Pepper" },
                    { new Guid("567ba975-9001-4e7e-b8f7-673110ddddda"), "Tomato" },
                    { new Guid("6eb21770-5dd3-429a-ab62-1555b0d36630"), "Onion" },
                    { new Guid("8cd50b33-ab8a-4ea7-9dfd-d617e635d06c"), "Cucumber" },
                    { new Guid("9cad758c-b689-499f-a8df-f3eeef122072"), "Lettuce" },
                    { new Guid("b0a4da29-0529-4e30-a33d-6da4e48bb35d"), "Garlic" },
                    { new Guid("f936a0af-e415-4678-9b09-1cc7e405c20c"), "Carrot" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("27c9d58c-c8ef-435d-b1a4-1f59f5616504"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("567ba975-9001-4e7e-b8f7-673110ddddda"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("6eb21770-5dd3-429a-ab62-1555b0d36630"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("8cd50b33-ab8a-4ea7-9dfd-d617e635d06c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9cad758c-b689-499f-a8df-f3eeef122072"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b0a4da29-0529-4e30-a33d-6da4e48bb35d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f936a0af-e415-4678-9b09-1cc7e405c20c"));

            migrationBuilder.AlterColumn<double>(
                name: "Votes",
                table: "Recipes",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
