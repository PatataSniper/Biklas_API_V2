using Biklas_API_V2;
using Itinero;
using System.Drawing;

namespace Biklas_API_V2.Services
{
    public interface ICalculadorRuta
    {
        Itinero.Route CalcularRutaOptima(Point ini, Point fin);
    }
}