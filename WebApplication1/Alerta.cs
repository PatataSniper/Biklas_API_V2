namespace Biklas_API_V2
{
    public class Alerta
    {
        [Key]
        public int IdAlerta { get; set; }

        [MaxLength(30)]
        public string Tipo { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }
        public System.DateTimeOffset FechaHora { get; set; }
        public int IdSegmento { get; set; }

        public virtual Segmento Segmento { get; set; }
    }
}
