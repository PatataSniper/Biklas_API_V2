namespace Biklas_API_V2
{
    public class Entidad
    {
        [Key]
        public int IdEntidad { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        public string NombreUI { get; set; }

        [MaxLength(100)]
        public string Icono { get; set; }

        public virtual ICollection<AccionEntidad> AccionEntidades { get; set; }
    }
}
