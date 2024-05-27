using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDealsAPI.Migrations
{
    public partial class CertificationCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ObtainedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ProfileId",
                table: "Certifications",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifications");
        }
    }
}
