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
    
    public abstract partial class Comprobante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comprobante()
        {
            this.DetalleComprobantes = new HashSet<DetalleComprobante>();
            this.Movimientos = new HashSet<Movimiento>();
            this.FormaPagos = new HashSet<FormaPago>();
        }
    
        public long Id { get; set; }
        public int Numero { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public long UsuarioId { get; set; }
        public long ClienteId { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormaPago> FormaPagos { get; set; }
    }
}
