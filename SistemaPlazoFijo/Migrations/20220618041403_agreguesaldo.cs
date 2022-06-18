using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPlazoFijo.Migrations
{
    public partial class agreguesaldo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "saldo",
                table: "Bancos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "saldo",
                table: "Bancos");
        }
    }
}
