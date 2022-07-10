namespace Biklas_API_V2
{
    public class UsuariosRelacion
    {
        public int IdUsuario { get; set; }
        public int IdUsuarioRelacionado { get; set; }
        public System.DateTime FechaRelacion { get; set; }

        public virtual Usuario Usuarios { get; set; }
        public virtual Usuario Usuarios1 { get; set; }
    }
}
