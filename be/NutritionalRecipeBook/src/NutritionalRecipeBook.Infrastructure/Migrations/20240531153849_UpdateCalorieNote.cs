using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCalorieNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CalorieNote",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0238f741-bf90-4135-8b86-dba649c348ad"), "Tomato" },
                    { new Guid("5ff22a21-d3be-444f-a615-46d4debb6b8f"), "Onion" },
                    { new Guid("6ced0088-fb8e-4c74-bd88-1b2867e64dac"), "Lettuce" },
                    { new Guid("70109788-7ffe-4015-9410-4040297c4ad6"), "Bell Pepper" },
                    { new Guid("9211c138-4a79-4c1b-a687-aadc18d0dbbe"), "Garlic" },
                    { new Guid("9473aa1b-6a0f-4a48-8fc5-6afc186307a3"), "Carrot" },
                    { new Guid("9efce453-7d8e-43ba-a657-5a7f584a7e5b"), "Cucumber" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalorieNote_UserId",
                table: "CalorieNote",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalorieNote_AspNetUsers_UserId",
                table: "CalorieNote",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalorieNote_AspNetUsers_UserId",
                table: "CalorieNote");

            migrationBuilder.DropIndex(
                name: "IX_CalorieNote_UserId",
                table: "CalorieNote");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("0238f741-bf90-4135-8b86-dba649c348ad"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("5ff22a21-d3be-444f-a615-46d4debb6b8f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("6ced0088-fb8e-4c74-bd88-1b2867e64dac"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("70109788-7ffe-4015-9410-4040297c4ad6"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9211c138-4a79-4c1b-a687-aadc18d0dbbe"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9473aa1b-6a0f-4a48-8fc5-6afc186307a3"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9efce453-7d8e-43ba-a657-5a7f584a7e5b"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CalorieNote");

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
    }
}
