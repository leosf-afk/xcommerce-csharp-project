using System;
using System.Collections.Generic;
using System.Linq;
using static Xcom.Servicio.Core.Comprobante.Descuento;

namespace Xcom.Servicio.Core.Comprobante.DTOs
{
    public class ComprobanteMesaDto
    {
        public ComprobanteMesaDto()
        {
            if (Items == null)
            {
                Items = new List<DetalleComprobanteSalonDto>();
            }
        }

        public long MesaId { get; set; }

        public long ComprobanteId { get; set; }

        public DateTime Fecha { get; set; }

        public long? MozoId { get; set; }

        public int Legajo { get; set; }

        public string ApellidoMozo { get; set; }

        public string NombreMozo { get; set; }

        public string ApyNom => $"{ApellidoMozo} {NombreMozo}";

        public AccesoDatos.EstadoComprobanteSalon Estado { get; set; }

        public long ClienteId { get; set; }

        public long UsuarioId { get; set; }

        public decimal SubTotal => Items.Sum(x => x.SubTotalLinea);

        public decimal Descuento { get; set; }

        public decimal Total => SubTotal - Calcular(Descuento ,SubTotal);

        public List<DetalleComprobanteSalonDto> Items { get; set; }
    }
}
