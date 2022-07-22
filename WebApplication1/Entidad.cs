namespace Biklas_API_V2
{
    public class Entidad
    {
        [Key]
        public int IdEntidad { get; set; }
        public string Nombre { get; set; }
        public string NombreUI { get; set; }
        public string Icono { get; set; }

        public virtual ICollection<AccionEntidad> AccionEntidades { get; set; }
    }
}
