using Itinero.LocalGeo;
using Microsoft.AspNetCore.Mvc;

namespace Biklas_API_V2.Controllers
{
    public class RutasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICalculadorRuta _calculadorRuta;

        public RutasController(DataContext context, ICalculadorRuta calculadorRuta)
        {
            _context = context;
            _calculadorRuta = calculadorRuta;
        }

        [HttpGet("api/Rutas/ObtenerRutasRelacionadas")]
        public ActionResult<object> ObtenerRutasRelacionadas(int idUsuario)
        {
            try
            {
                // Devuelve las rutas relacionadas. Convertimos las rutas a objetos 
                // anónimos para evitar ciclos infinitos. El nombre de las propiedades
                // de los objetos anónimos deberán cuadrar con los nombres las propiedades
                // declaradas en el cliente
                IEnumerable<Ruta> rutas = _context.Rutas.Include(r => r.Segmentos).ThenInclude(s => s.Arista)
                    .ThenInclude(a => a.VerticeInicial).Include(r => r.Segmentos).ThenInclude(s => s.Arista)
                    .ThenInclude(a => a.VerticeFinal).Where(r => r.IdUsuario == idUsuario);
                return Ok(rutas.Select(r => new
                {
                    id = r.IdRuta,
                    nombre = r.Nombre,
                    distancia = "10 km",
                    fechaCreacion = r.FechaCreacion.ToString(),
                    coordenadas = r.Coordenadas()
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("api/Rutas/ObtenerRutaOptima")]
        public ActionResult<object> ObtenerRutaOptima(float xIni, float yIni, float xFin, float yFin)
        {
            Itinero.Route ruta = _calculadorRuta.CalcularRutaOptima(new Coordinate(xIni, yIni), new Coordinate(xFin, yFin));
            return Ok(new { shape = _calculadorRuta.ObtenerFormaRutaGMR(ruta) });
        }

        private bool RutasExists(int id)
        {
            return _context.Rutas.Find(id) != null;
        }
    }
}
