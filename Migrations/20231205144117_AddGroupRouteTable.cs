using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IntuitiveTechTest.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupRouteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartureAirportGroupId = table.Column<int>(type: "integer", nullable: false),
                    ArrivalAirportGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupRoutes_AirportGroups_ArrivalAirportGroupId",
                        column: x => x.ArrivalAirportGroupId,
                        principalTable: "AirportGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupRoutes_AirportGroups_DepartureAirportGroupId",
                        column: x => x.DepartureAirportGroupId,
                        principalTable: "AirportGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoutes_ArrivalAirportGroupId",
                table: "GroupRoutes",
                column: "ArrivalAirportGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoutes_DepartureAirportGroupId_ArrivalAirportGroupId",
                table: "GroupRoutes",
                columns: new[] { "DepartureAirportGroupId", "ArrivalAirportGroupId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupRoutes");
        }
    }
}
