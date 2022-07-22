namespace Biklas_API_V2
{
    public class Vertice
    {
        [Key]
        public int IdVertice { get; set; }
        public decimal PosicionX { get; set; }
        public decimal PosicionY { get; set; }

        public virtual ICollection<Arista> AristasIniciales { get; set; }
        public virtual ICollection<Arista> AristasFinales { get; set; }
    }
}
