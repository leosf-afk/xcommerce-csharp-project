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
    
    public partial class PlanTarjeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanTarjeta()
        {
            this.FormaPagosTarjetas = new HashSet<FormaPagoTarjeta>();
        }
    
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Alicuota { get; set; }
        public long TarjetaId { get; set; }
    
        public virtual Tarjeta Tarjeta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormaPagoTarjeta> FormaPagosTarjetas { get; set; }
    }
}
