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
    
    public partial class ComprobanteSalon : Comprobante
    {
        public int Comensal { get; set; }
        public long MesaId { get; set; }
        public Nullable<long> MozoId { get; set; }
        public EstadoComprobanteSalon Estado { get; set; }
    
        public virtual Mesa Mesa { get; set; }
        public virtual Empleado Mozo { get; set; }
    }
}
