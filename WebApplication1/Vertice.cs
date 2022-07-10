namespace Biklas_API_V2
{
    public class Vertice
    {
        public int IdVertice { get; set; }
        public decimal PosicionX { get; set; }
        public decimal PosicionY { get; set; }

        public virtual ICollection<Arista> Aristas1 { get; set; }
        public virtual ICollection<Arista> Aristas2 { get; set; }
    }
}
