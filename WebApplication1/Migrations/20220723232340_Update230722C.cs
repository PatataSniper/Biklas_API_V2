using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biklas_API_V2.Migrations
{
    public partial class Update230722C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosicionFinX",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "PosicionFinY",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "PosicionInicioX",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "PosicionInicioY",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "TiempoFin",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "TiempoInicio",
                table: "Rutas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Rutas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdVerticeFinal",
                table: "Rutas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVerticeInicial",
                table: "Rutas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdVerticeFinal",
                table: "Rutas",
                column: "IdVerticeFinal");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdVerticeInicial",
                table: "Rutas",
                column: "IdVerticeInicial");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Vertices_IdVerticeFinal",
                table: "Rutas",
                column: "IdVerticeFinal",
                principalTable: "Vertices",
                principalColumn: "IdVertice");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Vertices_IdVerticeInicial",
                table: "Rutas",
                column: "IdVerticeInicial",
                principalTable: "Vertices",
                principalColumn: "IdVertice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Vertices_IdVerticeFinal",
                table: "Rutas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Vertices_IdVerticeInicial",
                table: "Rutas");

            migrationBuilder.DropIndex(
                name: "IX_Rutas_IdVerticeFinal",
                table: "Rutas");

            migrationBuilder.DropIndex(
                name: "IX_Rutas_IdVerticeInicial",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "IdVerticeFinal",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "IdVerticeInicial",
                table: "Rutas");

            migrationBuilder.AddColumn<decimal>(
                name: "PosicionFinX",
                table: "Rutas",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PosicionFinY",
                table: "Rutas",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PosicionInicioX",
                table: "Rutas",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PosicionInicioY",
                table: "Rutas",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TiempoFin",
                table: "Rutas",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TiempoInicio",
                table: "Rutas",
                type: "datetimeoffset",
                nullable: true);
        }
    }
}
