using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDealsAPI.Migrations
{
    public partial class HardSkillAndSoftSkillCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardSkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardSkills_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftSkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftSkills_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardSkills_ProfileId",
                table: "HardSkills",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkills_ProfileId",
                table: "SoftSkills",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardSkills");

            migrationBuilder.DropTable(
                name: "SoftSkills");
        }
    }
}
