

namespace Xcom.Servicio.Core.Precio.DTOs
{
    using System;

    public  class PrecioDto
    {
        public long Id { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public decimal PrecioPublicoRentabilidad { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public long ListaPrecioId { get; set; }

        public int ArticuloId { get; set; }

        public bool ActivarHoraVenta { get; set; }

        public DateTime HoraVenta { get; set; }
    }
}
