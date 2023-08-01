

namespace Xcom.Servicio.Core.Reserva.DTOs
{
    using System;
    using Xcom.AccesoDatos;

    public  class ReservaDto
    {

        public long Id { get; set; }

        public EstadoReserva EstadoReserva { get; set; }

        public long MotivoReservaId { get; set; }

        public decimal Senia { get; set; }

        public DateTime Fecha { get; set; }

        public long MesaId { get; set; }

        public long ClienteId { get; set; }



        public long UsuarioId { get; set; }
    }
}
