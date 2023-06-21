using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Avaliativo_Módulo_02.Migrations
{
    public partial class Criacao_Tabela_Modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdColecao = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Colecoes_IdColecao",
                        column: x => x.IdColecao,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "IdColecao", "Layout", "Nome", "Tipo" },
                values: new object[,]
                {
                    { 1, 3, 0, "Calça Rasgada", 4 },
                    { 2, 5, 2, "Chápeu de Palha", 7 },
                    { 3, 2, 1, "Camisa Estampa Dragão", 6 },
                    { 4, 4, 2, "Sapato Social", 5 },
                    { 5, 2, 0, "Bolsa de Couro", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoUsuario",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoUsuario",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoUsuario",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoUsuario",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoUsuario",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdColecao",
                table: "Modelos",
                column: "IdColecao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoUsuario",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoUsuario",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoUsuario",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoUsuario",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoUsuario",
                value: 1);
        }
    }
}
