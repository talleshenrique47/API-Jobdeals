using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDealsAPI.Migrations
{
    public partial class ExperiencesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Profiles_ProfileId",
                table: "Abouts");

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProfileId",
                table: "Experiences",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Profiles_ProfileId",
                table: "Abouts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Profiles_ProfileId",
                table: "Abouts");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Profiles_ProfileId",
                table: "Abouts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
