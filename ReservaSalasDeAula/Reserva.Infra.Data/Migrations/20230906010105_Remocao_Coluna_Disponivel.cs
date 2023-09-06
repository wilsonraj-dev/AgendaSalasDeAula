using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reserva.Infra.Data.Migrations
{
    public partial class Remocao_Coluna_Disponivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Agendas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Agendas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
