namespace Biklas_API_V2
{
    public class Accion
    {
        public int IdAccion { get; set; }
        public string Nombre { get; set; }
        public string NombreUI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccionEntidad> AccionEntidades { get; set; }
    }
}
