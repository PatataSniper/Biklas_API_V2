namespace Biklas_API_V2
{
    public class UsuariosRelacion
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioRelacionado { get; set; }
        public System.DateTime FechaRelacion { get; set; }

        public virtual Usuario Usuarios1 { get; set; }
        public virtual Usuario Usuarios2 { get; set; }
    }
}
