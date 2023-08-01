using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcom.Servicio.Core.Comprobante.DTOs
{
    public class DetalleComprobanteSalonDto
    {

        public long DetalleId { get; set; }

        public long ComprobanteId { get; set; }

        public long productoId { get; set; }

        public string CodigoProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal SubTotalLinea => decimal.Round(PrecioUnitario * Cantidad , 2 ,MidpointRounding.AwayFromZero);

      
    }
}
