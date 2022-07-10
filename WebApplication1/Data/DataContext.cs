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
    }
}
