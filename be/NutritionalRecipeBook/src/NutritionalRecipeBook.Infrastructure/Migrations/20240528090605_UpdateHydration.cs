using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHydration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hydration_HydrationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HydrationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HydrationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hydration",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hydration_UserId",
                table: "Hydration",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hydration_AspNetUsers_UserId",
                table: "Hydration",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hydration_AspNetUsers_UserId",
                table: "Hydration");

            migrationBuilder.DropIndex(
                name: "IX_Hydration_UserId",
                table: "Hydration");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hydration");

            migrationBuilder.AddColumn<Guid>(
                name: "HydrationId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HydrationId",
                table: "AspNetUsers",
                column: "HydrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hydration_HydrationId",
                table: "AspNetUsers",
                column: "HydrationId",
                principalTable: "Hydration",
                principalColumn: "Id");
        }
    }
}
