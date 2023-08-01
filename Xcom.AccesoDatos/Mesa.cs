//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xcom.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mesa()
        {
            this.Reservas = new HashSet<Reserva>();
            this.ComprobantesSalones = new HashSet<ComprobanteSalon>();
        }
    
        public long Id { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminado { get; set; }
        public long SalonId { get; set; }
        public EstadoMesa EstadoMesa { get; set; }
    
        public virtual Salon Salon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reservas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComprobanteSalon> ComprobantesSalones { get; set; }
    }
}
