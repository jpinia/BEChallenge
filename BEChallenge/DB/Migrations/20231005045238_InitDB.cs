using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    idOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    tipoOperacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.idOperacion);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    nroTarjeta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PIN = table.Column<int>(type: "int", nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nroCuenta = table.Column<int>(type: "int", nullable: false),
                    saldoActual = table.Column<double>(type: "float", nullable: false),
                    fechaUltimaExtraccion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.nroTarjeta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Tarjetas");
        }
    }
}
