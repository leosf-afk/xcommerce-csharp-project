using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcom.Servicio.Core.Comprobante.Comprobantes.ComprobanteDto
{
  public  class ComprobanteDetalleDto
    {
        public string codigo { get; set; }

        public string descripcion { get; set; }

        public decimal precioUnitario { get; set; }

        public decimal Cantidad  { get; set; }

        public decimal subtotal { get; set; }
    }
}
