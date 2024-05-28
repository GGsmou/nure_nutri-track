using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserHydration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserHydrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HydrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHydrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHydrations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHydrations_Hydration_HydrationId",
                        column: x => x.HydrationId,
                        principalTable: "Hydration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHydrations_HydrationId",
                table: "UserHydrations",
                column: "HydrationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHydrations_UserId",
                table: "UserHydrations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHydrations");

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
    }
}
