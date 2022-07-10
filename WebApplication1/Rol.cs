namespace Biklas_API_V2
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<AccionEntidad> AccionEntidad { get; set; }
    }
}
