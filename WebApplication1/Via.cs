namespace Biklas_API_V2
{
    public class Via
    {
        [Key]
        public int IdVia { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Arista> Aristas { get; set; }
    }
}
