using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Data.Migrations
{
    public partial class EntidadesOrdemAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmailComprador = table.Column<string>(nullable: true),
                    DataOrdem = table.Column<DateTimeOffset>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    StatusOrdem = table.Column<string>(nullable: false),
                    PaymentIntentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VagaAlugadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VagaOrdenada_NomeEstacionamento = table.Column<string>(nullable: true),
                    VagaOrdenada_NomeLogradouro = table.Column<string>(nullable: true),
                    VagaOrdenada_Numero = table.Column<string>(nullable: true),
                    VagaOrdenada_Cep = table.Column<string>(nullable: true),
                    VagaOrdenada_Bairro = table.Column<string>(nullable: true),
                    VagaOrdenada_Cidade = table.Column<string>(nullable: true),
                    VagaOrdenada_Estado = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaAlugadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VagaAlugadas_Ordens_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VagaAlugadas_OrdemId",
                table: "VagaAlugadas",
                column: "OrdemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VagaAlugadas");

            migrationBuilder.DropTable(
                name: "Ordens");
        }
    }
}
