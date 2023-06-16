using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Avaliativo_Módulo_02.Migrations
{
    public partial class Inicializacao_Tabela_Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf_Cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf_Cnpj", "Data", "Email", "Genero", "NomeCompleto", "NumeroTelefone", "Status", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "01191379908", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@mail.com", "Feminino", "Maria Fernanda", "49983762147", 1, 2 },
                    { 2, "01221379908", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jp@mail.com", "Masculino", "João Paulo", "49988562147", 2, 1 },
                    { 3, "01121779908", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mf@mail.com", "Masculino", "Martin Fowler", "48988562246", 1, 3 },
                    { 4, "01223378808", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "martin.c.@mail.com", "Masculino", "Uncle Bob", "48978567216", 1, 3 },
                    { 5, "01327388808", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lsp@mail.com", "Masculino", "Barbara Liskov", "48877567116", 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
