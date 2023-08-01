using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcom.Servicio.Core.FormaPago.DTOs
{
    public class EfectivoDto
    {
        public long Id { get; set; } 

        public long comprobanteId { get; set; }

        public int NumeroComprobante { get; set; }

        public  DateTime Fecha{ get; set; }

        public  decimal Monto { get; set; }

    }
}
