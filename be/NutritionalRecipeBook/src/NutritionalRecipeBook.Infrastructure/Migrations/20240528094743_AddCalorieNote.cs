using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCalorieNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CCalorieNoteId",
                table: "UserRecipes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CalorieNoteId",
                table: "UserRecipes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CalorieNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Calorie = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalorieNote", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipes_CalorieNoteId",
                table: "UserRecipes",
                column: "CalorieNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_CalorieNote_CalorieNoteId",
                table: "UserRecipes",
                column: "CalorieNoteId",
                principalTable: "CalorieNote",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_CalorieNote_CalorieNoteId",
                table: "UserRecipes");

            migrationBuilder.DropTable(
                name: "CalorieNote");

            migrationBuilder.DropIndex(
                name: "IX_UserRecipes_CalorieNoteId",
                table: "UserRecipes");

            migrationBuilder.DropColumn(
                name: "CCalorieNoteId",
                table: "UserRecipes");

            migrationBuilder.DropColumn(
                name: "CalorieNoteId",
                table: "UserRecipes");
        }
    }
}
