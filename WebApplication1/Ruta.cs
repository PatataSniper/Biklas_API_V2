using Itinero.LocalGeo;
using System.Drawing;

namespace Biklas_API_V2
{
    public class Ruta
    {
        [Key]
        public int IdRuta { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> PosicionInicioX { get; set; }
        public Nullable<decimal> PosicionInicioY { get; set; }
        public Nullable<decimal> PosicionFinX { get; set; }
        public Nullable<decimal> PosicionFinY { get; set; }
        public Nullable<System.DateTimeOffset> TiempoInicio { get; set; }
        public Nullable<System.DateTimeOffset> TiempoFin { get; set; }

        public virtual ICollection<Segmento> Segmentos { get; set; }

        /// <summary>
        /// Devuelve el conjunto de cordenadas (x,y) que describen la ruta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Coordinate> Coordenadas()
        {
            List<Coordinate> coordenadas = new List<Coordinate>();

            // Obtenemos los segmentos de ruta ordenados por posición
            Segmento[] segementos = Segmentos.OrderBy(s => s.Posicion).ToArray();

            foreach (Segmento se in segementos)
            {
                Vertice verF = se.Arista.VerticeFinal; // Vértice final
                if (se.EsElPrimero)
                {
                    // Obtenemos las coordenadas iniciales y finales del primer segmento. De los
                    // segmentos consiguientes solamente serán necesarias las coordenadas finales
                    Vertice verI = se.Arista.VerticeInicial; // Vértice inicial

                    // Agregamos las coordenadas iniciales
                    coordenadas.Add(new Coordinate((float)verI.PosicionX, (float)verI.PosicionY));
                }

                // Agregamos las coordenadas finales
                coordenadas.Add(new Coordinate((float)verF.PosicionX, (float)verF.PosicionY));
            }

            return coordenadas;
        }
    }
}
