using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Data.Migrations
{
    public partial class Localizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoEstacionamento",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoEstacionamento",
                table: "Locations");
        }
    }
}
