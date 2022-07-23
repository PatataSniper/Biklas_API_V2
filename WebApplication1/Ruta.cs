using Itinero.LocalGeo;

namespace Biklas_API_V2
{
    public class Ruta
    {
        public Ruta()
        {
            Segmentos = new List<Segmento>();
        }
        
        [Key]
        public int IdRuta { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [Precision(9,6)]
        public decimal? PosicionInicioX { get; set; }

        [Precision(9, 6)]
        public decimal? PosicionInicioY { get; set; }

        [Precision(9, 6)]
        public decimal? PosicionFinX { get; set; }

        [Precision(9, 6)]
        public decimal? PosicionFinY { get; set; }
        
        public DateTimeOffset? TiempoInicio { get; set; }
        
        public DateTimeOffset? TiempoFin { get; set; }

        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

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
