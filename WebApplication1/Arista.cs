namespace Biklas_API_V2
{
    public class Arista
    {
        [Key]
        public int IdArista { get; set; }
        public int NumeroCarriles1 { get; set; }
        public int? NumeroCarriles2 { get; set; }
        public bool Bidireccional { get; set; }
        public int? IdVerticeInicial { get; set; }
        public int? IdVerticeFinal { get; set; }
        public int IdVia { get; set; }

        public virtual Vertice? VerticeInicial { get; set; }
        public virtual Vertice? VerticeFinal { get; set; }
        public virtual Via Via { get; set; }
        public virtual ICollection<Segmento> Segmentos { get; set; }
    }
}
