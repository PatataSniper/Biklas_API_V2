namespace Biklas_API_V2
{
    public class UsuariosRelacion
    {
        public UsuariosRelacion()
        {
            Usuarios1 = new Usuario();
            Usuarios2 = new Usuario();
        }

        public UsuariosRelacion(int idUsuario, int idUsuarioRelacionado)
        {
            IdUsuario = idUsuario;
            IdUsuarioRelacionado = idUsuarioRelacionado;
            FechaRelacion = DateTime.Now.Date;
        }

        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioRelacionado { get; set; }
        public DateTime FechaRelacion { get; set; }

        public virtual Usuario Usuarios1 { get; set; }
        public virtual Usuario Usuarios2 { get; set; }
    }
}
