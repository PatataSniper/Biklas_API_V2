using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biklas_API_V2.Migrations
{
    public partial class CreateInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    IdAccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.IdAccion);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    IdEntidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.IdEntidad);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Vertices",
                columns: table => new
                {
                    IdVertice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicionX = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false),
                    PosicionY = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertices", x => x.IdVertice);
                });

            migrationBuilder.CreateTable(
                name: "Vias",
                columns: table => new
                {
                    IdVia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vias", x => x.IdVia);
                });

            migrationBuilder.CreateTable(
                name: "AccionEntidades",
                columns: table => new
                {
                    IdAccionEntidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntidad = table.Column<int>(type: "int", nullable: false),
                    IdAccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionEntidades", x => x.IdAccionEntidad);
                    table.ForeignKey(
                        name: "FK_AccionEntidades_Acciones_IdAccion",
                        column: x => x.IdAccion,
                        principalTable: "Acciones",
                        principalColumn: "IdAccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccionEntidades_Entidades_IdEntidad",
                        column: x => x.IdEntidad,
                        principalTable: "Entidades",
                        principalColumn: "IdEntidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmRecorridos = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aristas",
                columns: table => new
                {
                    IdArista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarriles1 = table.Column<int>(type: "int", nullable: false),
                    NumeroCarriles2 = table.Column<int>(type: "int", nullable: true),
                    Bidireccional = table.Column<bool>(type: "bit", nullable: false),
                    IdVerticeInicial = table.Column<int>(type: "int", nullable: true),
                    IdVerticeFinal = table.Column<int>(type: "int", nullable: true),
                    IdVia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aristas", x => x.IdArista);
                    table.ForeignKey(
                        name: "FK_Aristas_Vertices_IdVerticeFinal",
                        column: x => x.IdVerticeFinal,
                        principalTable: "Vertices",
                        principalColumn: "IdVertice");
                    table.ForeignKey(
                        name: "FK_Aristas_Vertices_IdVerticeInicial",
                        column: x => x.IdVerticeInicial,
                        principalTable: "Vertices",
                        principalColumn: "IdVertice");
                    table.ForeignKey(
                        name: "FK_Aristas_Vias_IdVia",
                        column: x => x.IdVia,
                        principalTable: "Vias",
                        principalColumn: "IdVia");
                });

            migrationBuilder.CreateTable(
                name: "AccionEntidadRol",
                columns: table => new
                {
                    AccionEntidadIdAccionEntidad = table.Column<int>(type: "int", nullable: false),
                    RolesIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionEntidadRol", x => new { x.AccionEntidadIdAccionEntidad, x.RolesIdRol });
                    table.ForeignKey(
                        name: "FK_AccionEntidadRol_AccionEntidades_AccionEntidadIdAccionEntidad",
                        column: x => x.AccionEntidadIdAccionEntidad,
                        principalTable: "AccionEntidades",
                        principalColumn: "IdAccionEntidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccionEntidadRol_Roles_RolesIdRol",
                        column: x => x.RolesIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    IdRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosicionInicioX = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    PosicionInicioY = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    PosicionFinX = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    PosicionFinY = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    TiempoInicio = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TiempoFin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.IdRuta);
                    table.ForeignKey(
                        name: "FK_Rutas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosRelaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRelacionado = table.Column<int>(type: "int", nullable: false),
                    FechaRelacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRelaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosRelaciones_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_UsuariosRelaciones_Usuarios_IdUsuarioRelacionado",
                        column: x => x.IdUsuarioRelacionado,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Segmentos",
                columns: table => new
                {
                    IdSegmento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posicion = table.Column<int>(type: "int", nullable: false),
                    IdArista = table.Column<int>(type: "int", nullable: false),
                    IdRuta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentos", x => x.IdSegmento);
                    table.ForeignKey(
                        name: "FK_Segmentos_Aristas_IdArista",
                        column: x => x.IdArista,
                        principalTable: "Aristas",
                        principalColumn: "IdArista");
                    table.ForeignKey(
                        name: "FK_Segmentos_Rutas_IdRuta",
                        column: x => x.IdRuta,
                        principalTable: "Rutas",
                        principalColumn: "IdRuta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHora = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdSegmento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_Alertas_Segmentos_IdSegmento",
                        column: x => x.IdSegmento,
                        principalTable: "Segmentos",
                        principalColumn: "IdSegmento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionEntidades_IdAccion",
                table: "AccionEntidades",
                column: "IdAccion");

            migrationBuilder.CreateIndex(
                name: "IX_AccionEntidades_IdEntidad",
                table: "AccionEntidades",
                column: "IdEntidad");

            migrationBuilder.CreateIndex(
                name: "IX_AccionEntidadRol_RolesIdRol",
                table: "AccionEntidadRol",
                column: "RolesIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_IdSegmento",
                table: "Alertas",
                column: "IdSegmento");

            migrationBuilder.CreateIndex(
                name: "IX_Aristas_IdVerticeFinal",
                table: "Aristas",
                column: "IdVerticeFinal");

            migrationBuilder.CreateIndex(
                name: "IX_Aristas_IdVerticeInicial",
                table: "Aristas",
                column: "IdVerticeInicial");

            migrationBuilder.CreateIndex(
                name: "IX_Aristas_IdVia",
                table: "Aristas",
                column: "IdVia");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdUsuario",
                table: "Rutas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Segmentos_IdArista",
                table: "Segmentos",
                column: "IdArista");

            migrationBuilder.CreateIndex(
                name: "IX_Segmentos_IdRuta",
                table: "Segmentos",
                column: "IdRuta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRelaciones_IdUsuario",
                table: "UsuariosRelaciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRelaciones_IdUsuarioRelacionado",
                table: "UsuariosRelaciones",
                column: "IdUsuarioRelacionado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccionEntidadRol");

            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "UsuariosRelaciones");

            migrationBuilder.DropTable(
                name: "AccionEntidades");

            migrationBuilder.DropTable(
                name: "Segmentos");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "Aristas");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Vertices");

            migrationBuilder.DropTable(
                name: "Vias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
