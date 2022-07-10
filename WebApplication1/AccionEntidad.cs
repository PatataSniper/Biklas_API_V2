namespace Biklas_API_V2
{
    public class AccionEntidad
    {
        public int IdAccionEntidad { get; set; }
        public int IdEntidad { get; set; }
        public int IdAccion { get; set; }

        public virtual Accion Accion { get; set; }
        public virtual Entidad Entidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rol> Roles { get; set; }
    }
}
