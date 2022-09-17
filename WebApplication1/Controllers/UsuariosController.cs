using Microsoft.AspNetCore.Mvc;

namespace Biklas_API_V2.Controllers
{
    public class UsuariosController : ControllerBase
    {
        private readonly IComunicadorCorreo _comunicadorCorreo;
        private readonly IEncriptador _encriptador;
        private readonly DataContext _context;

        public UsuariosController(DataContext context, IComunicadorCorreo comunicadorCorreo, IEncriptador encriptador)
        {
            _context = context;
            _comunicadorCorreo = comunicadorCorreo;
            _encriptador = encriptador;
        }

        // GET api/<controller>
        /// <summary>
        /// Devuelve al cliente la lista de usuarios almacenados en la BD.
        /// Se debe especificar el id del usuario que realiza la búsqueda,
        /// dicho usuario se excluye de los resultados. También se puede 
        /// especificar un texto de búsqueda el cual se usará como filtro
        /// para obtener los resultados.
        /// </summary>
        /// <param name="idUsuario">El id del usuario que realiza la búsqueda</param>
        /// <param name="textoBusqueda">El texto de búsqueda de usuarios</param>
        /// <returns></returns>
        [HttpGet("api/usuarios/busqueda")]
        public ActionResult<IEnumerable<object>> Get(int idUsuario, string? textoBusqueda = null)
        {
            // La búsqueda se estandariza a minúsculas
            textoBusqueda = textoBusqueda?.ToLower();

            // El usuario de búsqueda se excluye de los resultados...
            IEnumerable<Usuario> usuarios = _context.Usuarios.Include(u => u.UsuariosRelacion1)
                .Where(u => u.IdUsuario != idUsuario);

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                // Se especificó un texto de búsqueda, se utilizará como 
                // filtro para obtener los resultados. Las columnas de los
                // usuarios involucradas en la búsqueda son:
                // Nombre
                // Apellidos
                // Nombre de usuario
                usuarios = usuarios.Where(u => u.Nombre.ToLower().Contains(textoBusqueda)
                    || u.NombreUsuario.ToLower().Contains(textoBusqueda)
                    || u.Apellidos?.ToLower().Contains(textoBusqueda) == true);
            }

            List<object> result = new List<object>();
            result.AddRange(usuarios.Select(u => new
            {
                idUsuario = u.IdUsuario,
                nombre = u.Nombre,
                apellidos = u.Apellidos,
                nombreUsuario = u.NombreUsuario,
                contraseña = u.Contrasenia,
                correoElectronico = u.CorreoElectronico,
                idRol = u.IdRol,
                kmRecorridos = u.KmRecorridos,

                // Indicamos si es que ambos usuarios son amigos
                sonAmigos = u.SonAmigos(idUsuario)
            }));

            return Ok(result);
        }

        //GET api/<controller>/5
        [HttpGet("api/usuarios/{id}")]
        public async Task<ActionResult<object>> Get(int id)
        {
            try
            {
                Usuario? usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado en la base de datos");
                }

                return Ok(new
                {
                    usr = new
                    {
                        usuario.IdUsuario,
                        usuario.Nombre,
                        usuario.Apellidos,
                        usuario.NombreUsuario,
                        usuario.Contrasenia,
                        usuario.CorreoElectronico,
                        usuario.IdRol
                    }
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new { err = ex.Message });
            }
        }

        // POST api/<controller>
        [HttpPost("api/usuarios")]
        public async Task<ActionResult> Post([FromBody]Usuario nuevoUsuario)
        {
            try
            {
                // Normalizamos información de creación de usuario
                nuevoUsuario.NormalizarDatosCreacion(_encriptador, _context);
                _context.Usuarios.Add(nuevoUsuario);

                // Iniciamos proceso de guardado en BD
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    user = new
                    {
                        nuevoUsuario.IdUsuario,
                        nuevoUsuario.Nombre,
                        nuevoUsuario.Apellidos,
                        nuevoUsuario.NombreUsuario,
                        nuevoUsuario.Contrasenia,
                        nuevoUsuario.CorreoElectronico,
                        nuevoUsuario.IdRol
                    },
                    auth_token = "1" // Token de prueba
                });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Utilizará las credenciales del usuario para validar su existencia y acceso al sistema.
        /// Si las credenciales existen y son válidas, devuelve la información del usuario.
        /// </summary>
        /// <param name="identificador">El identificador del usuario (nombre o correo electrónico)</param>
        /// <param name="contra">La contraseña del usuario</param>
        /// <returns>Información del usuario existente en la BD</returns>
        [HttpGet("api/Usuarios/IniciarSesion")]
        public async Task<ActionResult<object>> IniciarSesion(string identificador, string contra)
        {
            try
            {
                // Recibimos credenciales con los siguientes datos del usuario
                // Identificador: Puede tratarse del nombre del usuario, o del correo del usuario (Ambos datos
                // son válidos como identificador)
                // Contraseña: La contraseña del usuario
                Usuario? usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.NombreUsuario == identificador || u.CorreoElectronico == identificador);

                if (usuario == null) throw new Exception("Usuario no existe en la base de datos");

                // El usuario existe, validamos la contraseña
                if (usuario.ValidarContra(contra, _encriptador))
                {
                    // Contraseña válida, éxito en el inicio de sesión, devolvemos información del usuario
                    return Ok(new
                    {
                        user = new
                        {
                            usuario.IdUsuario,
                            usuario.Nombre,
                            usuario.Apellidos,
                            usuario.NombreUsuario,
                            usuario.Contrasenia,
                            usuario.CorreoElectronico,
                            usuario.IdRol
                        },
                        auth_token = "1" // Token de prueba
                    });
                }

                // Contraseña inválida, fallo en el inicio de sesión
                throw new Exception("Contraseña incorrecta");
            }
            catch (Exception ex)
            {
                return BadRequest(new { err = ex.Message });
            }
        }

        [HttpPost("api/usuarios/recuperarcontrasenia/{correo}")]
        public async Task<ActionResult> RecuperarContrasenia(string correo)
        {
            try
            {
                // Obtenemos el email del usuario relacionado
                Usuario? usr = await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoElectronico == correo);

                if (usr == null)
                {
                    // Correo no relacionado a ningún usuario en la base de datos
                    throw new Exception("El correo no pertenece a ningún usuario");
                }

                // Enviamos correo de recuperación de contraseña al usuario
                _comunicadorCorreo.EnviarCorreoRecuperacionContra(usr.CorreoElectronico, usr.Contrasenia,
                    Credenciales.CORREO_ELECTRONICO_COM, Credenciales.CONTRA_CORREO_ELECTRONICO_COM);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(new { err = ex.Message });
            }
        }
    }
}
