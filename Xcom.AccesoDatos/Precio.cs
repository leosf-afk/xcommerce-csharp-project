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
    
    public partial class Precio
    {
        public long Id { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioPublico { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public long ListaPrecioId { get; set; }
        public int ArticuloId { get; set; }
        public bool ActivarHoraVenta { get; set; }
        public System.DateTime HoraVenta { get; set; }
    
        public virtual ListaPrecio ListaPrecio { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}
