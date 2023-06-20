using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Avaliativo_Módulo_02.Migrations
{
    public partial class Criação_da_Tabela_Colecoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdResponsavel = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Orcamento = table.Column<double>(type: "float", nullable: false),
                    AnoLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estacao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colecoes_Usuarios_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colecoes",
                columns: new[] { "Id", "AnoLancamento", "Estacao", "IdResponsavel", "Marca", "Nome", "Orcamento", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, "Adidas", "Outono Inverno", 250000.0, 1 },
                    { 2, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Oakley", "Florescer da Mata", 1000000.0, 0 },
                    { 3, new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Nike", "Esfriou", 100000.0, 1 },
                    { 4, new DateTime(2004, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, "Calvin Klein", "Vem verão", 250000.0, 1 },
                    { 5, new DateTime(2010, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "Puma", "Moda Fitnes", 428900.0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_IdResponsavel",
                table: "Colecoes",
                column: "IdResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colecoes");
        }
    }
}
