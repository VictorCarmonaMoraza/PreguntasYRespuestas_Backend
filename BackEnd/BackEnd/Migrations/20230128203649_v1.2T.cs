using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v12T : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaId",
                principalTable: "Respuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaId",
                principalTable: "Respuesta",
                principalColumn: "Id");
        }
    }
}
