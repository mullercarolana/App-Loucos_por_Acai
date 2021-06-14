using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Loucos_por_Acai.Migrations
{
    public partial class AlteracoesModeloDominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmEstoque",
                table: "Lanches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLanchePreferido",
                table: "Lanches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmEstoque",
                table: "Lanches");

            migrationBuilder.DropColumn(
                name: "IsLanchePreferido",
                table: "Lanches");
        }
    }
}
