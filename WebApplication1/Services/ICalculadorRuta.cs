using Biklas_API_V2;
using Itinero.LocalGeo;

namespace Biklas_API_V2.Services
{
    public interface ICalculadorRuta
    {
        Itinero.Route CalcularRutaOptima(Coordinate ini, Coordinate fin, Stream mapa);

        object[] ObtenerFormaRutaGMR(Itinero.Route ruta);
    }
}