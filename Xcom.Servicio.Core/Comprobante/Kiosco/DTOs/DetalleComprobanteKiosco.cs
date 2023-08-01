using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcom.Servicio.Core.Comprobante.Kiosco.DTOs
{
  public   class DetalleComprobanteKiosco
    {
        public long DetalleId { get; set; }

        public int ArticuloId { get; set; }

        public long ComprobanteId { get; set; }

        public long productoId { get; set; }

        public string CodigoProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Subtotal { get; set; }
    }
}
