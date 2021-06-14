using Microsoft.EntityFrameworkCore.Migrations;

namespace App_Loucos_por_Acai.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaId,CategoriaNome) VALUES(1,'Açaí Pequeno')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaId,CategoriaNome) VALUES(2,'Açaí Médio')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaId,CategoriaNome) VALUES(3,'Acaí Grande')");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(1,'Tamanho 330ml', 'Com Leite em Pó, Leite Condensado, Morangos e Chocolates MMs', 12.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(2,'Tamanho 550ml', 'Com Leite em Pó, Leite Condensado, Morangos e Chocolates MMs', 16.00, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(3,'Tamanho 770ml', 'Com Leite em Pó, Leite Condensado, Morangos e Chocolates MMs', 19.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(1,'Tamanho 330ml', 'Com Granola, Kiwi, Banana e Morangos', 12.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(2,'Tamanho 550ml', 'Com Granola, Kiwi, Banana e Morangos', 16.00, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(3,'Tamanho 770ml', 'Com Granola, Kiwi, Banana e Morangos', 19.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(1,'Tamanho 330ml', 'Com Nutela, KitKat, Leite Condensado e Leite em Pó', 12.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(2,'Tamanho 550ml', 'Com Nutela, KitKat, Leite Condensado e Leite em Pó', 16.00, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(3,'Tamanho 770ml', 'Com Nutela, KitKat, Leite Condensado e Leite em Pó', 19.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(1,'Tamanho 330ml', 'Com Bis, Chocolates MMs, Leite Condensado e Leite em Pó', 12.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(2,'Tamanho 550ml', 'Com Bis, Chocolates MMs, Leite Condensado e Leite em Pó', 16.00, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(3,'Tamanho 770ml', 'Com Bis, Chocolates MMs, Leite Condensado e Leite em Pó', 19.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(1,'Tamanho 330ml', 'Com Sucrilhos, Banana, Morango e Leite Condensado', 12.00, 0, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(2,'Tamanho 550ml', 'Com Sucrilhos, Banana, Morango e Leite Condensado', 16.00, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,Nome,DescricaoComplementos,Preco,IsLanchePreferido,EmEstoque) VALUES(3,'Tamanho 770ml', 'Com Sucrilhos, Banana, Morango e Leite Condensado', 19.00, 0, 1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
