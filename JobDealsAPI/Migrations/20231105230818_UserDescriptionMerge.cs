using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDealsAPI.Migrations
{
    public partial class UserDescriptionMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Description_UserId",
                table: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Description_UserId",
                table: "Description",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Description_UserId",
                table: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Description_UserId",
                table: "Description",
                column: "UserId");
        }
    }
}
