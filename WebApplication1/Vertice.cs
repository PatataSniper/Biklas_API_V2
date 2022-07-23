namespace Biklas_API_V2
{
    public class Vertice
    {
        public Vertice()
        {
            AristasIniciales = new List<Arista>();
            AristasFinales = new List<Arista>();
        }

        public Vertice(double x, double y)
        {
            PosicionX = x;
            PosicionY = y;
            
            AristasIniciales = new List<Arista>();
            AristasFinales = new List<Arista>();
        }
        
        [Key]
        public int IdVertice { get; set; }

        [Precision(9, 6)]
        public double PosicionX { get; set; }

        [Precision(9, 6)]
        public double PosicionY { get; set; }

        public virtual ICollection<Arista> AristasIniciales { get; set; }
        public virtual ICollection<Arista> AristasFinales { get; set; }
    }
}
