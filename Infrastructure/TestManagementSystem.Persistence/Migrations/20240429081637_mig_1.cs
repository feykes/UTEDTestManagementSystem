using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Team = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PhaseNo = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Findings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportanceLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Round = table.Column<byte>(type: "tinyint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToWho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Findings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Findings_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FindingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Findings_FindingId",
                        column: x => x.FindingId,
                        principalTable: "Findings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_FindingId",
                table: "Files",
                column: "FindingId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_TestId",
                table: "Findings",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Findings");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
