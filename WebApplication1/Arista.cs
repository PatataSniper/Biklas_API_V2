namespace Biklas_API_V2
{
    public class Arista
    {
        public int IdArista { get; set; }
        public int NumeroCarriles1 { get; set; }
        public Nullable<int> NumeroCarriles2 { get; set; }
        public bool Bidireccional { get; set; }
        public int IdVerticeInicial { get; set; }
        public int IdVerticeFinal { get; set; }
        public int IdVia { get; set; }

        public virtual Vertice Vertice1 { get; set; }
        public virtual Vertice Vertice2 { get; set; }
        public virtual Via Via { get; set; }
        public virtual ICollection<Segmento> Segmentos { get; set; }
    }
}
