using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biklas_API_V2.Migrations
{
    public partial class Contra64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ContraseniaH",
                table: "Usuarios",
                type: "varbinary(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(60)",
                oldMaxLength: 60);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ContraseniaH",
                table: "Usuarios",
                type: "varbinary(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(64)",
                oldMaxLength: 64);
        }
    }
}
