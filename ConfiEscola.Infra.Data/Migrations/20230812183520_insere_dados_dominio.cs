using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfiEscola.Infra.Data.Migrations
{
    public partial class insere_dados_dominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Escolaridade",
               columns: new[] { "Id", "Descricao" },
               values: new object[,] {
                    { 1, "Infantil" },
                    { 2, "Fundamental" },
                    { 3, "Médio" },
                    { 4, "Superior" } }
               );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var keyValues = new Object[] { 1, 2, 3, 4 };

            migrationBuilder.DeleteData(
                table: "Escolaridade",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValues: keyValues);

        }
    }
}