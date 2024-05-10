using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    public partial class FirstMySqlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.CarritoSesionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SesionDetalles",
                columns: table => new
                {
                    CarritoSesionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProductoSeleccionado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarritoSesionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionDetalles", x => x.CarritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_SesionDetalles_Sessions_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "Sessions",
                        principalColumn: "CarritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SesionDetalles_CarritoSesionId",
                table: "SesionDetalles",
                column: "CarritoSesionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SesionDetalles");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
