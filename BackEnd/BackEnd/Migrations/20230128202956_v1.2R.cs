using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v12R : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_RespuestaCuestionario_RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_RespuestaCuestionario_RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaCuestionarioId",
                principalTable: "RespuestaCuestionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_RespuestaCuestionario_RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_RespuestaCuestionario_RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaCuestionarioId",
                principalTable: "RespuestaCuestionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
