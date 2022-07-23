using Microsoft.EntityFrameworkCore;

namespace Biklas_API_V2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuariosRelacion> UsuariosRelaciones { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<AccionEntidad> AccionEntidades { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Arista> Aristas { get; set; }
        public DbSet<Vertice> Vertices { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Via> Vias { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuramos las relaciones entre las entidades
            modelBuilder.Entity<Arista>()
                .HasOne(a => a.VerticeInicial)
                .WithMany(v => v.AristasIniciales)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(a => a.IdVerticeInicial);

            modelBuilder.Entity<Arista>()
                .HasOne(a => a.VerticeFinal)
                .WithMany(v => v.AristasFinales)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(a => a.IdVerticeFinal);

            modelBuilder.Entity<Arista>()
                .HasOne(a => a.Via)
                .WithMany(v => v.Aristas)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasForeignKey(a => a.IdVia);

            modelBuilder.Entity<UsuariosRelacion>()
                .HasOne(r => r.Usuarios1)
                .WithMany(u => u.UsuariosRelacion1)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(r => r.IdUsuario);

            modelBuilder.Entity<UsuariosRelacion>()
                .HasOne(r => r.Usuarios2)
                .WithMany(u => u.UsuariosRelacion2)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(r => r.IdUsuarioRelacionado);

            modelBuilder.Entity<AccionEntidad>()
                .HasOne(ae => ae.Accion)
                .WithMany(a => a.AccionEntidades)
                .HasForeignKey(ae => ae.IdAccion);

            modelBuilder.Entity<AccionEntidad>()
                .HasOne(ae => ae.Entidad)
                .WithMany(a => a.AccionEntidades)
                .HasForeignKey(ae => ae.IdEntidad);

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.Segmento)
                .WithMany(al => al.Alertas)
                .HasForeignKey(a => a.IdSegmento);

            modelBuilder.Entity<Segmento>()
                .HasOne(s => s.Arista)
                .WithMany(a => a.Segmentos)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasForeignKey(s => s.IdArista);

            modelBuilder.Entity<Segmento>()
                .HasOne(s => s.Ruta)
                .WithMany(r => r.Segmentos)
                .HasForeignKey(s => s.IdRuta);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol);

            modelBuilder.Entity<Ruta>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Rutas)
                .HasForeignKey(r => r.IdUsuario);

            modelBuilder.Entity<Rol>()
                .HasMany(r => r.AccionEntidad)
                .WithMany(ae => ae.Roles);
        }
    }
}
