using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class RemovendoIdSolicitante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante_Id",
                table: "SolicitacaoCompra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSolicitante_Id",
                table: "SolicitacaoCompra",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
