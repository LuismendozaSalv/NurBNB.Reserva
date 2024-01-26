using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NURBNB.Alojamiento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReservasPropiedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservapropiedad",
                columns: table => new
                {
                    reservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoReserva = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    tipoPago = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    montoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    guestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservapropiedad", x => x.reservaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservapropiedad");
        }
    }
}
