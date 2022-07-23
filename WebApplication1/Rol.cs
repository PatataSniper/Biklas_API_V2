namespace Biklas_API_V2
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<AccionEntidad> AccionEntidad { get; set; }
    }
}
