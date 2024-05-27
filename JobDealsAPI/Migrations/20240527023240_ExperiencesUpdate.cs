using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDealsAPI.Migrations
{
    public partial class ExperiencesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Experiences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Experiences",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);
        }
    }
}
