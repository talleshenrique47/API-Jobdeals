using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDealsAPI.Migrations
{
    public partial class AcademicFormationCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicFormations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institution = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Course = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicFormations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicFormations_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicFormations_ProfileId",
                table: "AcademicFormations",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicFormations");
        }
    }
}
