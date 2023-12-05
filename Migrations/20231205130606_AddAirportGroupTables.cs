using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntuitiveTechTest.Migrations
{
    /// <inheritdoc />
    public partial class AddAirportGroupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportGroupJunctions",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "integer", nullable: false),
                    AirportGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportGroupJunctions", x => new { x.AirportId, x.AirportGroupId });
                    table.ForeignKey(
                        name: "FK_AirportGroupJunctions_AirportGroups_AirportGroupId",
                        column: x => x.AirportGroupId,
                        principalTable: "AirportGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportGroupJunctions_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportGroupJunctions_AirportGroupId",
                table: "AirportGroupJunctions",
                column: "AirportGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportGroupJunctions");

            migrationBuilder.DropTable(
                name: "AirportGroups");
        }
    }
}
