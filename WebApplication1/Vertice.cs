namespace Biklas_API_V2
{
    public class Vertice
    {
        [Key]
        public int IdVertice { get; set; }

        [Precision(9, 6)]
        public decimal PosicionX { get; set; }

        [Precision(9, 6)]
        public decimal PosicionY { get; set; }

        public virtual ICollection<Arista> AristasIniciales { get; set; }
        public virtual ICollection<Arista> AristasFinales { get; set; }
    }
}
