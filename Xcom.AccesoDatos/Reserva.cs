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
    
    public partial class Reserva
    {
        public long Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Senia { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
        public long MesaId { get; set; }
        public long ClienteId { get; set; }
        public long UsuarioId { get; set; }
        public long MotivoReservaId { get; set; }
    
        public virtual Mesa Mesa { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual MotivoReserva MotivoReserva { get; set; }
    }
}
