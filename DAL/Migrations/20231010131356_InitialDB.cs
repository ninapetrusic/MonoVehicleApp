using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abrv = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleMakeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abrv = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[,]
                {
                    { 1, "Vw", "Volkswagen" },
                    { 2, "Porsche", "Dr. Ing. h. c. F. Porsche AG" },
                    { 3, "Toyota", "Toyota Motor Corporation" },
                    { 4, null, "Mazda" },
                    { 5, "Hyundai", "Hyundai Motor Company" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Abrv", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 1, "Golf III", "Golf Mk3", 1 },
                    { 2, null, "924", 2 },
                    { 3, null, "Celica", 3 },
                    { 4, null, "RX-7", 4 },
                    { 5, null, "i30 N", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_VehicleMakeId",
                table: "Models",
                column: "VehicleMakeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
