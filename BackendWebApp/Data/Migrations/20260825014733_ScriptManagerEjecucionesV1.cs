using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ScriptManagerEjecucionesV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabeceraOperacion",
                columns: table => new
                {
                    IdCabeceraOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabeceraOperacion", x => x.IdCabeceraOperacion);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOperacion",
                columns: table => new
                {
                    IdDetalleOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    Igv = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    IdCabeceraOperacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOperacion", x => x.IdDetalleOperacion);
                    table.ForeignKey(
                        name: "FK_DetalleOperacion_CabeceraOperacion_IdCabeceraOperacion",
                        column: x => x.IdCabeceraOperacion,
                        principalTable: "CabeceraOperacion",
                        principalColumn: "IdCabeceraOperacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOperacion_IdCabeceraOperacion",
                table: "DetalleOperacion",
                column: "IdCabeceraOperacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOperacion");

            migrationBuilder.DropTable(
                name: "CabeceraOperacion");
        }
    }
}
