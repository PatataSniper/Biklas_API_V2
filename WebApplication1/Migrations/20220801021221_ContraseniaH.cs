using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biklas_API_V2.Migrations
{
    public partial class ContraseniaH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "Usuarios");

            migrationBuilder.AddColumn<byte[]>(
                name: "ContraseniaH",
                table: "Usuarios",
                type: "varbinary(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContraseniaH",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "Usuarios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
