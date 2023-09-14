using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reserva.Infra.Data.Migrations
{
    public partial class Alteracao_Tipo_De_Mapeamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Salas_SalaId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_SalaId",
                table: "Agendas");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_SalaId",
                table: "Agendas",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Salas_SalaId",
                table: "Agendas",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Salas_SalaId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_SalaId",
                table: "Agendas");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_SalaId",
                table: "Agendas",
                column: "SalaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Salas_SalaId",
                table: "Agendas",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }
    }
}
