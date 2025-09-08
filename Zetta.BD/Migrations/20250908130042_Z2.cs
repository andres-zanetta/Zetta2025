using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zetta.BD.Migrations
{
    /// <inheritdoc />
    public partial class Z2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ClienteId",
                table: "Obras",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Clientes_ClienteId",
                table: "Obras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Clientes_ClienteId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_ClienteId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Obras");
        }
    }
}
