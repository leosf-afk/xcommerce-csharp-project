using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.AccesoDatos;

namespace Xcom.Servicio.Core.DetalleCaja.DTOs
{
   public  class DetalleCajaDto
    {
        public long Id { get; set; }

        public long CajaId { get; set; }

        public decimal Monto { get; set; }

        public TipoPago TipoPago { get; set; }
    }
}
