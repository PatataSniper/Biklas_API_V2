﻿// <auto-generated />
using System;
using Biklas_API_V2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biklas_API_V2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220801024131_Contra64")]
    partial class Contra64
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AccionEntidadRol", b =>
                {
                    b.Property<int>("AccionEntidadIdAccionEntidad")
                        .HasColumnType("int");

                    b.Property<int>("RolesIdRol")
                        .HasColumnType("int");

                    b.HasKey("AccionEntidadIdAccionEntidad", "RolesIdRol");

                    b.HasIndex("RolesIdRol");

                    b.ToTable("AccionEntidadRol");
                });

            modelBuilder.Entity("Biklas_API_V2.Accion", b =>
                {
                    b.Property<int>("IdAccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccion"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreUI")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAccion");

                    b.ToTable("Acciones");
                });

            modelBuilder.Entity("Biklas_API_V2.AccionEntidad", b =>
                {
                    b.Property<int>("IdAccionEntidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccionEntidad"), 1L, 1);

                    b.Property<int>("IdAccion")
                        .HasColumnType("int");

                    b.Property<int>("IdEntidad")
                        .HasColumnType("int");

                    b.HasKey("IdAccionEntidad");

                    b.HasIndex("IdAccion");

                    b.HasIndex("IdEntidad");

                    b.ToTable("AccionEntidades");
                });

            modelBuilder.Entity("Biklas_API_V2.Alerta", b =>
                {
                    b.Property<int>("IdAlerta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlerta"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTimeOffset>("FechaHora")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdSegmento")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdAlerta");

                    b.HasIndex("IdSegmento");

                    b.ToTable("Alertas");
                });

            modelBuilder.Entity("Biklas_API_V2.Arista", b =>
                {
                    b.Property<int>("IdArista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArista"), 1L, 1);

                    b.Property<bool>("Bidireccional")
                        .HasColumnType("bit");

                    b.Property<int?>("IdVerticeFinal")
                        .HasColumnType("int");

                    b.Property<int?>("IdVerticeInicial")
                        .HasColumnType("int");

                    b.Property<int>("IdVia")
                        .HasColumnType("int");

                    b.Property<int>("NumeroCarriles1")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroCarriles2")
                        .HasColumnType("int");

                    b.HasKey("IdArista");

                    b.HasIndex("IdVerticeFinal");

                    b.HasIndex("IdVerticeInicial");

                    b.HasIndex("IdVia");

                    b.ToTable("Aristas");
                });

            modelBuilder.Entity("Biklas_API_V2.Entidad", b =>
                {
                    b.Property<int>("IdEntidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntidad"), 1L, 1);

                    b.Property<string>("Icono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NombreUI")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdEntidad");

                    b.ToTable("Entidades");
                });

            modelBuilder.Entity("Biklas_API_V2.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Biklas_API_V2.Ruta", b =>
                {
                    b.Property<int>("IdRuta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRuta"), 1L, 1);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdVerticeFinal")
                        .HasColumnType("int");

                    b.Property<int>("IdVerticeInicial")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRuta");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdVerticeFinal");

                    b.HasIndex("IdVerticeInicial");

                    b.ToTable("Rutas");
                });

            modelBuilder.Entity("Biklas_API_V2.Segmento", b =>
                {
                    b.Property<int>("IdSegmento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSegmento"), 1L, 1);

                    b.Property<int>("IdArista")
                        .HasColumnType("int");

                    b.Property<int>("IdRuta")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.HasKey("IdSegmento");

                    b.HasIndex("IdArista");

                    b.HasIndex("IdRuta");

                    b.ToTable("Segmentos");
                });

            modelBuilder.Entity("Biklas_API_V2.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("ContraseniaH")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varbinary(64)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<decimal>("KmRecorridos")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Biklas_API_V2.UsuariosRelacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaRelacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioRelacionado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdUsuarioRelacionado");

                    b.ToTable("UsuariosRelaciones");
                });

            modelBuilder.Entity("Biklas_API_V2.Vertice", b =>
                {
                    b.Property<int>("IdVertice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVertice"), 1L, 1);

                    b.Property<double>("PosicionX")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<double>("PosicionY")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.HasKey("IdVertice");

                    b.ToTable("Vertices");
                });

            modelBuilder.Entity("Biklas_API_V2.Via", b =>
                {
                    b.Property<int>("IdVia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVia"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdVia");

                    b.ToTable("Vias");
                });

            modelBuilder.Entity("AccionEntidadRol", b =>
                {
                    b.HasOne("Biklas_API_V2.AccionEntidad", null)
                        .WithMany()
                        .HasForeignKey("AccionEntidadIdAccionEntidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biklas_API_V2.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesIdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biklas_API_V2.AccionEntidad", b =>
                {
                    b.HasOne("Biklas_API_V2.Accion", "Accion")
                        .WithMany("AccionEntidades")
                        .HasForeignKey("IdAccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biklas_API_V2.Entidad", "Entidad")
                        .WithMany("AccionEntidades")
                        .HasForeignKey("IdEntidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accion");

                    b.Navigation("Entidad");
                });

            modelBuilder.Entity("Biklas_API_V2.Alerta", b =>
                {
                    b.HasOne("Biklas_API_V2.Segmento", "Segmento")
                        .WithMany("Alertas")
                        .HasForeignKey("IdSegmento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segmento");
                });

            modelBuilder.Entity("Biklas_API_V2.Arista", b =>
                {
                    b.HasOne("Biklas_API_V2.Vertice", "VerticeFinal")
                        .WithMany("AristasFinales")
                        .HasForeignKey("IdVerticeFinal")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Biklas_API_V2.Vertice", "VerticeInicial")
                        .WithMany("AristasIniciales")
                        .HasForeignKey("IdVerticeInicial")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Biklas_API_V2.Via", "Via")
                        .WithMany("Aristas")
                        .HasForeignKey("IdVia")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("VerticeFinal");

                    b.Navigation("VerticeInicial");

                    b.Navigation("Via");
                });

            modelBuilder.Entity("Biklas_API_V2.Ruta", b =>
                {
                    b.HasOne("Biklas_API_V2.Usuario", "Usuario")
                        .WithMany("Rutas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biklas_API_V2.Vertice", "VerticeFinal")
                        .WithMany("RutasFinales")
                        .HasForeignKey("IdVerticeFinal")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Biklas_API_V2.Vertice", "VerticeInicial")
                        .WithMany("RutasIniciales")
                        .HasForeignKey("IdVerticeInicial")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("VerticeFinal");

                    b.Navigation("VerticeInicial");
                });

            modelBuilder.Entity("Biklas_API_V2.Segmento", b =>
                {
                    b.HasOne("Biklas_API_V2.Arista", "Arista")
                        .WithMany("Segmentos")
                        .HasForeignKey("IdArista")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Biklas_API_V2.Ruta", "Ruta")
                        .WithMany("Segmentos")
                        .HasForeignKey("IdRuta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arista");

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("Biklas_API_V2.Usuario", b =>
                {
                    b.HasOne("Biklas_API_V2.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Biklas_API_V2.UsuariosRelacion", b =>
                {
                    b.HasOne("Biklas_API_V2.Usuario", "Usuarios1")
                        .WithMany("UsuariosRelacion1")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Biklas_API_V2.Usuario", "Usuarios2")
                        .WithMany("UsuariosRelacion2")
                        .HasForeignKey("IdUsuarioRelacionado")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuarios1");

                    b.Navigation("Usuarios2");
                });

            modelBuilder.Entity("Biklas_API_V2.Accion", b =>
                {
                    b.Navigation("AccionEntidades");
                });

            modelBuilder.Entity("Biklas_API_V2.Arista", b =>
                {
                    b.Navigation("Segmentos");
                });

            modelBuilder.Entity("Biklas_API_V2.Entidad", b =>
                {
                    b.Navigation("AccionEntidades");
                });

            modelBuilder.Entity("Biklas_API_V2.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Biklas_API_V2.Ruta", b =>
                {
                    b.Navigation("Segmentos");
                });

            modelBuilder.Entity("Biklas_API_V2.Segmento", b =>
                {
                    b.Navigation("Alertas");
                });

            modelBuilder.Entity("Biklas_API_V2.Usuario", b =>
                {
                    b.Navigation("Rutas");

                    b.Navigation("UsuariosRelacion1");

                    b.Navigation("UsuariosRelacion2");
                });

            modelBuilder.Entity("Biklas_API_V2.Vertice", b =>
                {
                    b.Navigation("AristasFinales");

                    b.Navigation("AristasIniciales");

                    b.Navigation("RutasFinales");

                    b.Navigation("RutasIniciales");
                });

            modelBuilder.Entity("Biklas_API_V2.Via", b =>
                {
                    b.Navigation("Aristas");
                });
#pragma warning restore 612, 618
        }
    }
}
