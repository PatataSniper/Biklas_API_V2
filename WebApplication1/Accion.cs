
namespace Biklas_API_V2
{
    public class Accion
    {
        [Key]
        public int IdAccion { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string NombreUI { get; set; }

        public virtual ICollection<AccionEntidad> AccionEntidades { get; set; }
    }
}
