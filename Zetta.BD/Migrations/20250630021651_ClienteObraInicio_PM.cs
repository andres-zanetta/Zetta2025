using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zetta.BD.Migrations
{
    /// <inheritdoc />
    public partial class ClienteObraInicio_PM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemPresupuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Rubro = table.Column<int>(type: "int", nullable: false),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechActuPrecio = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPresupuestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rubro = table.Column<int>(type: "int", nullable: false),
                    Aceptado = table.Column<bool>(type: "bit", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ManodeObra = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalP = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TiempoAproxObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidacionDias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpcionDePago = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuestos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresupuestoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obras_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Obras_Presupuestos_PresupuestoId",
                        column: x => x.PresupuestoId,
                        principalTable: "Presupuestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresItemDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresupuestoId = table.Column<int>(type: "int", nullable: false),
                    ItemPresupuestoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresItemDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresItemDetalles_ItemPresupuestos_ItemPresupuestoId",
                        column: x => x.ItemPresupuestoId,
                        principalTable: "ItemPresupuestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresItemDetalles_Presupuestos_PresupuestoId",
                        column: x => x.PresupuestoId,
                        principalTable: "Presupuestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ObraId",
                table: "Obras",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_PresupuestoId",
                table: "Obras",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_PresItemDetalles_ItemPresupuestoId",
                table: "PresItemDetalles",
                column: "ItemPresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_PresItemDetalles_PresupuestoId",
                table: "PresItemDetalles",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_ClienteId",
                table: "Presupuestos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "PresItemDetalles");

            migrationBuilder.DropTable(
                name: "ItemPresupuestos");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
