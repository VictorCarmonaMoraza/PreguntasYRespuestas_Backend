using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v12L : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CuestionarioId",
                table: "RespuestaCuestionario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario",
                column: "CuestionarioId",
                principalTable: "Cuestionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaId",
                principalTable: "Respuesta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaCuestionarioId",
                table: "RespuestaCuestionarioDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CuestionarioId",
                table: "RespuestaCuestionario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario",
                column: "CuestionarioId",
                principalTable: "Cuestionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionarioDetalles_Respuesta_RespuestaId",
                table: "RespuestaCuestionarioDetalles",
                column: "RespuestaId",
                principalTable: "Respuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
