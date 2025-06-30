using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zetta.BD.Migrations
{
    /// <inheritdoc />
    public partial class SM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObraId",
                table: "Obras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ObraId",
                table: "Obras",
                column: "ObraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Obras_ObraId",
                table: "Obras",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Obras_ObraId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_ObraId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "ObraId",
                table: "Obras");
        }
    }
}
