using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biklas_API_V2
{
    public class Usuario
    {
        public const int ID_ROL_POR_DEFECTO = 1; // Administrador por defecto

        public Usuario()
        {
            Rutas = new List<Ruta>();
            Rol = new Rol();
            Nombre = string.Empty;
            Contrasenia = string.Empty;
            ContraseniaH = Array.Empty<byte>();
            Apellidos = string.Empty;
            NombreUsuario = string.Empty;
            CorreoElectronico = string.Empty;
        }

        [Key]
        public int IdUsuario { get; set; }
        
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        [NotMapped]
        public string Contrasenia { get; set; }

        [MaxLength(64)]
        public byte[] ContraseniaH { get; set; }

        [Precision(9, 2)]
        public decimal KmRecorridos { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        
        [MaxLength(100)]
        public string CorreoElectronico { get; set; }
        public int IdRol { get; set; }

        public virtual ICollection<UsuariosRelacion> UsuariosRelacion1 { get; set; }
        public virtual ICollection<UsuariosRelacion> UsuariosRelacion2 { get; set; }
        public virtual ICollection<Ruta> Rutas { get; set; }
        public virtual Rol? Rol { get; set; }

        /// <summary>
        /// Validamos que la contraseña recibida como parámetro, sea igual a la contraseña
        /// del usuario
        /// </summary>
        /// <param name="contra">Contraseña a validar</param>
        /// <param name="encriptador">Servicio encriptador utilizado para desencriptar la
        /// contraseña proveniente de la base de datos</param>
        /// <returns>true si las contraseñas son iguales, de lo contrario, false</returns>
        public bool ValidarContra(string contra, IEncriptador encriptador)
        {
            // Es necesario desencriptar la contraseña proveniente de la base de datos
            return encriptador.Desencriptar(ContraseniaH, encriptador.Llave, encriptador.IV) == contra;
        }

        /// <summary>
        /// Indica si el usuario actual tiene relación con el usuario especificado
        /// como parámetro
        /// </summary>
        /// <param name="idUsuario">El id del usuario especificado</param>
        /// <returns></returns>
        public bool SonAmigos(int idUsuario)
        {
            return UsuariosRelacion1.Any(a => a.IdUsuarioRelacionado == idUsuario);
        }

        /// <summary>
        /// Normaliza los datos de la entidad para su posterior almacenamiento en la 
        /// base de datos. Utilizado durante creación de entidad
        /// </summary>
        /// <param name="encriptador">Servicio de encriptación utilizado para encriptar
        /// la contraseña del usuario</param>
        public void NormalizarDatosCreacion(IEncriptador encriptador, DataContext ctx)
        {
            // Asignamos identificadores válidos
            //IdUsuario = Usuarios.NuevoId(Db);
            IdRol = ID_ROL_POR_DEFECTO;
            Rol = ctx.Roles.Find(IdRol);
            KmRecorridos = 0;
            FechaRegistro = DateTime.Now;

            NormalizarDatos(encriptador);
        }

        /// <summary>
        /// Normaliza los datos de la entidad para su posterior almacenamiento en la 
        /// base de datos
        /// </summary>
        /// <param name="encriptador">Servicio de encriptación utilizado para encriptar
        /// la contraseña del usuario</param>
        public void NormalizarDatos(IEncriptador encriptador)
        {
            // Encriptamos contraseña para su almacenamiento en BD
            ContraseniaH = encriptador.Encriptar(Contrasenia, encriptador.Llave, encriptador.IV);
        }
    }
}
