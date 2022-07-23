namespace Biklas_API_V2
{
    public class Segmento
    {
        public Segmento()
        {
            Alertas = new List<Alerta>();
            Arista = new Arista();
            Ruta = new Ruta();
        }
        
        [Key]
        public int IdSegmento { get; set; }
        public int Posicion { get; set; }
        public int IdArista { get; set; }
        public int IdRuta { get; set; }

        public virtual ICollection<Alerta> Alertas { get; set; }
        public virtual Arista Arista { get; set; }
        public virtual Ruta Ruta { get; set; }

        public bool EsElPrimero => Posicion == 1;

        //public bool EsElUltimo()
        //{

        //}
    }
}
