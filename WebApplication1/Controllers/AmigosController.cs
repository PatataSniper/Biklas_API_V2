using Microsoft.AspNetCore.Mvc;

namespace Biklas_API_V2.Controllers
{
    public class AmigosController : ControllerBase
    {
        private readonly DataContext _context;

        public AmigosController(DataContext context)
        {
            _context = context;
        }
        
        // GET: ObtenerAmigosRelacionados
        [HttpGet("api/Amigos/ObtenerAmigosRelacionados")]
        public ActionResult ObtenerAmigosRelacionados(int idUsuario)
        {
            try
            {
                // Get the user from database
                Usuario? usr = _context.Usuarios.Include(u => u.UsuariosRelacion1).ThenInclude(rln => rln.Usuarios2)
                    .FirstOrDefault(u => u.IdUsuario == idUsuario);
                if (usr == null)
                {
                    throw new Exception("Usuario no encontrado en la base de datos");
                }

                // Return the related friends as response
                List<object> listaAmigos = new List<object>();
                foreach (UsuariosRelacion rln in usr.UsuariosRelacion1)
                {
                    // We parse the friends and related users objects to 
                    // anonymous objects to avoid an infinite loop. The name
                    // of the anonymous object properties should match the
                    // names declared in the interface 'amigo' in the file
                    // 'amigos-context.ts' (client).
                    listaAmigos.Add(new
                    {
                        id = rln.IdUsuarioRelacionado,
                        nombre = rln.Usuarios2.Nombre,
                        apellidos = rln.Usuarios2.Apellidos,
                        nombreUsuario = rln.Usuarios2.NombreUsuario,
                        fechaNacimiento = rln.Usuarios2.FechaNacimiento,
                        kmRecorridos = rln.Usuarios2.KmRecorridos,
                        amigosDesde = rln.FechaRelacion
                    });
                }

                return Ok(new { listaAmigos });
            }
            catch (Exception ex)
            {
                return BadRequest(new { err = ex.Message });
            }
        }

        [HttpDelete("api/Amigos/EliminarAmigo")]
        public async Task<ActionResult> EliminarAmigo([FromBody]UsuariosRelacion relacion)
        {
            try
            {
                // Obtenemos los identificadores de relación del objeto recibido como parámetro
                int idUsuario = relacion.IdUsuario;
                int idUsuarioRelacionado = relacion.IdUsuarioRelacionado;

                // Obtenemos la relaciones de amistad entre ambos usuarios
                List<UsuariosRelacion> relaciones = _context.UsuariosRelaciones
                    .Where(a => a.IdUsuario == idUsuario && a.IdUsuarioRelacionado == idUsuarioRelacionado
                    || a.IdUsuario == idUsuarioRelacionado && a.IdUsuarioRelacionado == idUsuario)
                    .ToList();

                // Las eliminamos de la base de datos
                _context.UsuariosRelaciones.RemoveRange(relaciones);
                
                await _context.SaveChangesAsync();
                return Ok(new { });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("api/Amigos/AgregarAmigo")]
        public async Task<ActionResult> AgregarAmigo([FromBody]UsuariosRelacion relacion)
        {
            try
            {
                // Obtenemos los identificadores de relación del objeto recibido como parámetro
                int id1 = relacion.IdUsuario;
                int id2 = relacion.IdUsuarioRelacionado;

                // Creamos y agregamos la relación entre ambos usuarios
                _context.UsuariosRelaciones.AddRange(new List<UsuariosRelacion>()
                {
                    // Dos registros, la relación es bilateral. El constructor configura la 
                    // fecha de creación
                    new UsuariosRelacion(id1, id2),
                    new UsuariosRelacion(id2, id1)
                });

                await _context.SaveChangesAsync();
                return Ok(new { });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}