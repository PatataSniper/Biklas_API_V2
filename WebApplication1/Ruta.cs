using System.Drawing;

namespace Biklas_API_V2
{
    public class Ruta
    {
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
        /// Constructor que genera un objeto de ruta utilizable en el proyecto Biklas_API 
        /// a partir de un objeto 'Itinero.Route'
        /// </summary>
        /// <param name="route"></param>
        public Ruta(Route route)
        {
            //foreach (var coord in route.Shape)
            //{
            //    this.Coordenadas.Add(new Point((double)coord.Latitude, (double)coord.Longitude));
            //}
        }

        /// <summary>
        /// Devuelve el conjunto de cordenadas (x,y) que describen la ruta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point> Coordenadas()
        {
            List<Point> coordenadas = new List<Point>();

            // Obtenemos los segmentos de ruta ordenados por posición
            Segmento[] segementos = Segmentos.OrderBy(s => s.Posicion).ToArray();

            foreach (Segmento se in segementos)
            {
                Vertice verF = se.Arista.Vertice2; // Vértice final
                if (se.EsElPrimero)
                {
                    // Obtenemos las coordenadas iniciales y finales del primer segmento. De los
                    // segmentos consiguientes solamente serán necesarias las coordenadas finales
                    Vertice verI = se.Arista.Vertice1; // Vértice inicial

                    // Agregamos las coordenadas iniciales
                    coordenadas.Add(new Point((double)verI.PosicionX, (double)verI.PosicionY));
                }

                // Agregamos las coordenadas finales
                coordenadas.Add(new Point((double)verF.PosicionX, (double)verF.PosicionY));
            }

            return coordenadas;
        }
    }
}
