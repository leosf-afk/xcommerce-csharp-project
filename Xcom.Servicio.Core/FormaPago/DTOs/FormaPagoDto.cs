using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;

namespace Xcom.Servicio.Core.FormaPago.DTOs
{
    public class FormaPagoDto
    {
        public long Id { get; set; }

        public long ComprobanteId { get; set; }

        public TipoFormaPago FormaPago { get; set; }

        public decimal Monto { get; set; }

        public long clienteId { get; set; }

        public bool EstaPagado { get; set; }

    }

}
