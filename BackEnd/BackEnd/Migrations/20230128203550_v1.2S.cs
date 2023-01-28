using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v12S : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario");

            migrationBuilder.AlterColumn<int>(
                name: "CuestionarioId",
                table: "RespuestaCuestionario",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario",
                column: "CuestionarioId",
                principalTable: "Cuestionario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario");

            migrationBuilder.AlterColumn<int>(
                name: "CuestionarioId",
                table: "RespuestaCuestionario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaCuestionario_Cuestionario_CuestionarioId",
                table: "RespuestaCuestionario",
                column: "CuestionarioId",
                principalTable: "Cuestionario",
                principalColumn: "Id");
        }
    }
}
